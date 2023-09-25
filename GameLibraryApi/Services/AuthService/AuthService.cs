using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GameLibraryApi.Common.Exceptions;
using GameLibraryApi.Data;
using GameLibraryApi.DTO.Auth;
using GameLibraryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GameLibraryApi.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public string Register(RegisterDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if (user is not null)
                throw CustomExceptions.ALREADY_REGISTERED;

            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password); // şifreyi direk olarak kaydetmemek için hashliyoruz.
            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = PasswordHash,
                Role = request.Role
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return "Successful";
        }

        public string Login(LoginDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username.ToLower().Equals(request.Username.ToLower()));
            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw CustomExceptions.LOGIN_ERROR;
            string token = CreateToken(user);
            return token;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username), // tokana username bilgisini ekledik
                new Claim(ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!
            )); // token keyini AppSettings'den aldık

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); // şifreleme işlemi

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            ); // oluşacak token için bilgiler.

            var jwt = new JwtSecurityTokenHandler().WriteToken(token); // tokeni oluşturma

            return jwt;
        }
    }
}