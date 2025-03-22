using FluentValidation;

namespace DDD.Kitchen.Application.Restaurants.Commands.DeleteRestaurant;

/// <summary>
/// Validator for the DeleteRestaurantCommand.
/// </summary>
public sealed class DeleteRestaurantCommandValidator : AbstractValidator<DeleteRestaurantCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteRestaurantCommandValidator"/> class.
    /// </summary>
    public DeleteRestaurantCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id cannot be null.")
            .NotEmpty().WithMessage("Id cannot be empty.");
    }
}