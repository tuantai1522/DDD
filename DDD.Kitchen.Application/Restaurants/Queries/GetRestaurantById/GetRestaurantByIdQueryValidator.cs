using FluentValidation;

namespace DDD.Kitchen.Application.Restaurants.Queries.GetRestaurantById;

/// <summary>
/// Validator for the GetRestaurantByIdQuery.
/// </summary>
public sealed class GetRestaurantByIdQueryValidator : AbstractValidator<GetRestaurantByIdQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetRestaurantByIdQueryValidator"/> class.
    /// </summary>
    public GetRestaurantByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id cannot be null.");
    }
}