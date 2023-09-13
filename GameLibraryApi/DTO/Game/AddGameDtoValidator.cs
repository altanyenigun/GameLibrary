using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using GameLibraryApi.Common;

namespace GameLibraryApi.DTO.Game
{
    public class AddGameDtoValidator : AbstractValidator<AddGameDto>
    {
        public AddGameDtoValidator()
        {
            RuleFor(command => command.Metascore).NotNull().GreaterThan(0).LessThanOrEqualTo(100);
            RuleFor(command => command.Userscore).NotNull().GreaterThan(0).LessThanOrEqualTo(10);
            RuleFor(command => command.Name).NotNull().MinimumLength(1);
            RuleFor(command => command.GameMode).NotEmpty();
            RuleFor(command => command.Genre).NotEmpty();
            RuleFor(command => command.Platform).NotEmpty();

        }
    }
}