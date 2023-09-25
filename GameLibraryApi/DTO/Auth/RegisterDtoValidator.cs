using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace GameLibraryApi.DTO.Auth
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(u=>u.Username).NotEmpty().MinimumLength(4);
            RuleFor(u=>u.Password).NotEmpty().MinimumLength(4);
        }
    }
}