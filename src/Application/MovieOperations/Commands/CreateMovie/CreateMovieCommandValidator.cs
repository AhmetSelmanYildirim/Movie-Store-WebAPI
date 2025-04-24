using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Price).GreaterThan(0);
            RuleFor(command => command.Model.Year.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Genre).NotEmpty();
        }
    }
}
