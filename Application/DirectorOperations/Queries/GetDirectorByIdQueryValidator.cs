using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.DirectorOperations.Queries
{
    public class GetDirectorByIdQueryValidator : AbstractValidator<GetDirectorByIdQuery>
    {
        public GetDirectorByIdQueryValidator()
        {
            RuleFor(command => command.DirectorId).GreaterThan(0).WithMessage("\n Id must greater than 0");
        }
    }
}
