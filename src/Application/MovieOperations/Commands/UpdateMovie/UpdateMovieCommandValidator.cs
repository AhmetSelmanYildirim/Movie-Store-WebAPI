using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);
            RuleFor(command => command.Model.Genre).NotEmpty();
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Price).GreaterThan(0);
            RuleFor(command => command.Model.Year).LessThan(DateTime.Now.Date);
        }
    }
}
