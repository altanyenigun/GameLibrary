using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace GameLibraryApi.DTO.Game
{
    public class ListGameDtoValidator : AbstractValidator<ListGameDto>
    {
        public ListGameDtoValidator()
        {
            RuleFor(command=>command.Field).NotEmpty();
            RuleFor(command=>command.OrderBy).NotEmpty().Must(c=> c == "ASC" || c == "DESC" ||  c == "asc" || c == "desc").WithMessage("It can only be 'ASC','asc' or 'DESC','desc'.");   
        }
    }
}