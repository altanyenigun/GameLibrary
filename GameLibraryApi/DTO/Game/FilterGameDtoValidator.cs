using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace GameLibraryApi.DTO.Game
{
    public class FilterGameDtoValidator : AbstractValidator<FilterGameDto>
    {
        public FilterGameDtoValidator()
        {
            // This is a class of rules created to prevent logical errors that may occur in filtering.
            // For example, minUserscore should not be greater than maxUserscore or minReleaseDate should not be greater than maxReleaseDate.

            RuleFor(f => f.MinMetascore)
                .InclusiveBetween(0, 100)
                .When(x => x.MinMetascore > 0);
            RuleFor(f => f.MinMetascore)
                .LessThan(f => f.MaxMetascore)
                .When(x => x.MinMetascore > 0 && x.MaxMetascore > 0).WithMessage("MinMetascore value cannot be greater than MaxMetascore value!");;

            RuleFor(f => f.MaxMetascore)
                .InclusiveBetween(0, 100)
                .When(x => x.MaxMetascore > 0);
            RuleFor(f => f.MaxMetascore)
                .GreaterThan(f => f.MinMetascore)
                .When(x => x.MinMetascore > 0 && x.MaxMetascore > 0).WithMessage("Max Metascore value cannot be less than Min Metascore value!");

            RuleFor(f => f.MinUserscore)
                .InclusiveBetween(0, 10)
                .When(x => x.MinUserscore > 0);
            RuleFor(f => f.MinUserscore)
                .LessThan(f => f.MaxUserscore)
                .When(x => x.MinUserscore > 0 && x.MaxUserscore > 0).WithMessage("MinUserscore value cannot be greater than MaxUserscore value!");

            RuleFor(f => f.MaxUserscore)
                .InclusiveBetween(0, 10)
                .When(x => x.MaxUserscore > 0);
            RuleFor(f => f.MaxUserscore)
                .GreaterThan(f => f.MinUserscore)
                .When(x => x.MinUserscore > 0 && x.MaxUserscore > 0).WithMessage("MaxUserscore value cannot be less than MinUserscore value!");

            RuleFor(x => x.MinReleaseDate)
                .Must((model, minReleaseDate) => !minReleaseDate.HasValue || !model.MaxReleaseDate.HasValue || minReleaseDate <= model.MaxReleaseDate)
                .WithMessage("MinReleaseDate cannot be greater than MaxReleaseDate.");

            RuleFor(x => x.MaxReleaseDate)
                .Must((model, maxReleaseDate) => !maxReleaseDate.HasValue || !model.MinReleaseDate.HasValue || maxReleaseDate >= model.MinReleaseDate)
                .WithMessage("MaxReleaseDate cannot be less than MinReleaseDate.");
        
        }
    }
}