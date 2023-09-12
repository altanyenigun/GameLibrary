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
            RuleFor(command => command.GameMode).Custom((list, context) =>
            {
                if (list!.Count < 1)
                {
                    context.AddFailure("List cant be empty");
                }
                foreach (var item in list)
                {
                    if (!Enum.IsDefined(typeof(GameMode), item))
                    {
                        context.AddFailure("Invalid GameMode in list,please check!");
                    }
                }
            });
            RuleFor(command => command.Genre).Custom((list, context) =>
            {
                if (list!.Count < 1)
                {
                    context.AddFailure("List cant be empty");
                }
                foreach (var item in list)
                {
                    if (!Enum.IsDefined(typeof(GenreEnum), item))
                    {
                        context.AddFailure("Invalid Genre in list,please check!");
                    }
                }
            });
            RuleFor(command => command.Platform).Custom((list, context) =>
            {
                if (list!.Count < 1)
                {
                    context.AddFailure("List cant be empty");
                }
                foreach (var item in list)
                {
                    if (!Enum.IsDefined(typeof(PlatformEnum), item))
                    {
                        context.AddFailure("Invalid Platform in list,please check!");
                    }
                }
            });

        }
    }
}