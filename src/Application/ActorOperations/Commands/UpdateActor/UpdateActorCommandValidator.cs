using FluentValidation;
using Movie_Store_WebAPI.Application.ActorOperations.Commads.UpdateActor;
using System;


namespace Movie_Store_WebAPI.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(command => command.Model.Surname).NotEmpty();
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
        }
    }
}
