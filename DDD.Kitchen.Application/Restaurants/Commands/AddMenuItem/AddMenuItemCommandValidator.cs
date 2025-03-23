using DDD.Kitchen.Application.Restaurants.Commands.CreateRestaurant;
using FluentValidation;

namespace DDD.Kitchen.Application.Restaurants.Commands.AddMenuItem;

/// <summary>
/// Validator for the CreateRestaurantCommand.
/// </summary>
public sealed class AddMenuItemCommandValidator : AbstractValidator<AddMenuItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddMenuItemCommandValidator"/> class.
    /// </summary>
    public AddMenuItemCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name cannot be null.")
            .NotEmpty().WithMessage("Name cannot be empty.");
        
        RuleFor(x => x.Price)
            .NotNull().WithMessage("Price cannot be null.")
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
        
        RuleFor(x => x.RestaurantId)
            .NotNull().WithMessage("Restaurant Id cannot be null.")
            .NotEmpty().WithMessage("Restaurant Id cannot be empty.");
    }
}