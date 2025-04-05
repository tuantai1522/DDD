using FluentValidation;

namespace DDD.Kitchen.Application.Tickets.Commands.CreateTicket;

/// <summary>
/// Validator for the CreateTicketCommand.
/// </summary>
public sealed class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTicketCommandValidator"/> class.
    /// </summary>
    public CreateTicketCommandValidator()
    {
        RuleFor(x => x.Tickets)
            .NotNull().WithMessage("Tickets cannot be null.")
            .NotEmpty().WithMessage("Tickets cannot be empty.");
        
    }
}