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
            RuleFor(f => f.MinMetascore)
                .InclusiveBetween(0, 100)
                .When(x => x.MinMetascore > 0);
            RuleFor(f => f.MinMetascore)
                .LessThan(f => f.MaxMetascore)
                .When(x => x.MinMetascore > 0 && x.MaxMetascore > 0).WithMessage("MinMetascore değeri MaxMetascore değerinden büyük olamaz!");;

            RuleFor(f => f.MaxMetascore)
                .InclusiveBetween(0, 100)
                .When(x => x.MaxMetascore > 0);
            RuleFor(f => f.MaxMetascore)
                .GreaterThan(f => f.MinMetascore)
                .When(x => x.MinMetascore > 0 && x.MaxMetascore > 0).WithMessage("MaxMetascore değeri MinMetascore değerinden küçük olamaz!");

            RuleFor(f => f.MinUserscore)
                .InclusiveBetween(0, 10)
                .When(x => x.MinUserscore > 0);
            RuleFor(f => f.MinUserscore)
                .LessThan(f => f.MaxUserscore)
                .When(x => x.MinUserscore > 0 && x.MaxUserscore > 0).WithMessage("MinUserscore değeri MaxUserscore değerinden büyük olamaz!");

            RuleFor(f => f.MaxUserscore)
                .InclusiveBetween(0, 10)
                .When(x => x.MaxUserscore > 0);
            RuleFor(f => f.MaxUserscore)
                .GreaterThan(f => f.MinUserscore)
                .When(x => x.MinUserscore > 0 && x.MaxUserscore > 0).WithMessage("MaxUserscore değeri MinUserscore değerinden küçük olamaz!");

            RuleFor(x => x.MinReleaseDate)
                .Must((model, minReleaseDate) => !minReleaseDate.HasValue || !model.MaxReleaseDate.HasValue || minReleaseDate <= model.MaxReleaseDate)
                .WithMessage("MinReleaseDate, MaxReleaseDate'den büyük olamaz.");

            RuleFor(x => x.MaxReleaseDate)
                .Must((model, maxReleaseDate) => !maxReleaseDate.HasValue || !model.MinReleaseDate.HasValue || maxReleaseDate >= model.MinReleaseDate)
                .WithMessage("MaxReleaseDate, MinReleaseDate'den küçük olamaz.");
        
        }
    }
}