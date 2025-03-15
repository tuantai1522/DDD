using Carter;
using DDD.Kitchen.Application.Restaurants.Queries.GetRestaurantById;
using DDD.Kitchen.Application.Restaurants.Queries.GetRestaurants;
using DDD.Kitchen.WebApi.Extensions;
using MediatR;

namespace DDD.Kitchen.WebApi.Endpoints;

public class RestaurantsEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/restaurants");
        
        group.MapGet("", GetRestaurants).WithName(nameof(GetRestaurants));
        group.MapGet("{id}", GetRestaurantById).WithName(nameof(GetRestaurantById));
    }

    private static async Task<IResult> GetRestaurants(IMediator mediator)
    {
        var result = await mediator.Send(new GetRestaurantsQuery());

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }

    private static async Task<IResult> GetRestaurantById(Guid id, IMediator mediator)
    {
        var result = await mediator.Send(new GetRestaurantByIdQuery(id));

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }
}