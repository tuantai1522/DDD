using DDD.Kitchen.Application.Restaurants.Commands.CreateRestaurant;
using FluentValidation;

namespace DDD.Kitchen.Application.Restaurants.Commands.UpdateRestaurant;

/// <summary>
/// Validator for the UpdateRestaurantCommand.
/// </summary>
public sealed class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateRestaurantCommandValidator"/> class.
    /// </summary>
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id cannot be null.")
            .NotEmpty().WithMessage("Id cannot be empty.");
        
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name cannot be null.")
            .NotEmpty().WithMessage("Name cannot be empty.");
    }
}