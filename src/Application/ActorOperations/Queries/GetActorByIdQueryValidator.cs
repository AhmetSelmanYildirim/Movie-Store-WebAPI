using FluentValidation;

namespace Movie_Store_WebAPI.Application.ActorOperations.Queries
{
    public class GetActorByIdQueryValidator : AbstractValidator<GetActorByIdQuery>
    {
        public GetActorByIdQueryValidator()
        {
            RuleFor(command => command.ActorId).GreaterThan(0);
        }
    }
}
