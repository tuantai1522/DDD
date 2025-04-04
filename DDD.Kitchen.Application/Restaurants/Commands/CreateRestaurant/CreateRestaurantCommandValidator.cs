using FluentValidation;

namespace DDD.Kitchen.Application.Restaurants.Commands.CreateRestaurant;

/// <summary>
/// Validator for the CreateRestaurantCommand.
/// </summary>
public sealed class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRestaurantCommandValidator"/> class.
    /// </summary>
    public CreateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name cannot be null.")
            .NotEmpty().WithMessage("Name cannot be empty.");
        
        RuleFor(x => x.Street)
            .NotNull().WithMessage("Street cannot be null.")
            .NotEmpty().WithMessage("Street cannot be empty.");
        
        RuleFor(x => x.Country)
            .NotNull().WithMessage("Country cannot be null.")
            .NotEmpty().WithMessage("Country cannot be empty.");
    }
}