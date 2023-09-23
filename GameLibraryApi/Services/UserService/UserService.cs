using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GameLibraryApi.Data;
using GameLibraryApi.DTO.User;
using GameLibraryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GameLibraryApi.Services.UserService
{
    public class UserService : IUserService
    {
        public static User user = new User();
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public string Register(UserRegisterDto request)
        {
            var user = _context.Users.FirstOrDefault(u=>u.Username == request.Username);
            if(user is not null)
                throw new Exception("User already registered, pick another username");

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

        public string Login(UserLoginDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username.ToLower().Equals(request.Username.ToLower()));
            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash) )
            {
                throw new InvalidOperationException("Wrong Username or Password!");
            }
            string token = CreateToken(user);
            return token;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Name",user.Username) // tokana username bilgisini ekledik
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