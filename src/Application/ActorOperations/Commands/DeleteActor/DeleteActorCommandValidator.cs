using FluentValidation;
using Movie_Store_WebAPI.Application.ActorOperations.Commads.DeleteActor;


namespace Movie_Store_WebAPI.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(command => command.ActorId).GreaterThan(0);
        }
    }
}
