using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);
        }
    }
}
