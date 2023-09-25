using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
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
            //Checking whether the incoming data is valid or not
            RegisterDtoValidator validator = new RegisterDtoValidator();
            validator.ValidateAndThrow(request);


            //Checking whether a user has already been created with the incoming username
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if (user is not null)
                throw CustomExceptions.ALREADY_REGISTERED;

            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password); //Creating a hashed password with the password that comes with the help of BCrypt.Net-Next Package
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

            //Checking if the user exists and the password is correct
            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw CustomExceptions.LOGIN_ERROR;

            string token = CreateToken(user);
            return token;
        }


        //Creating jwt token based on logged in user information.
        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Adding Id information to the token
                new Claim(ClaimTypes.Name,user.Username), // Adding Username information to the token
                new Claim(ClaimTypes.Role,user.Role) // Adding Role information to the token
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!
            )); //Receiving the token we created in appsettings.json

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); //some encryption operations

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            ); //Defining the information to be included in the token.

            var jwt = new JwtSecurityTokenHandler().WriteToken(token); //Creating the token after all processing

            return jwt;
        }
    }
}