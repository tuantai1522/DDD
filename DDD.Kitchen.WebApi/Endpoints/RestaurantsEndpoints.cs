using Carter;
using DDD.Kitchen.Application.Restaurants.Commands.AddMenuItem;
using DDD.Kitchen.Application.Restaurants.Commands.CreateRestaurant;
using DDD.Kitchen.Application.Restaurants.Commands.DeleteRestaurant;
using DDD.Kitchen.Application.Restaurants.Commands.UpdateRestaurant;
using DDD.Kitchen.Application.Restaurants.Queries.GetRestaurantById;
using DDD.Kitchen.Application.Restaurants.Queries.GetRestaurants;
using DDD.Kitchen.Domain.Aggregate;
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
        group.MapPost("", CreateRestaurant).WithName(nameof(CreateRestaurant));
        group.MapPost("menu-items/{id}", AddMenuItem).WithName(nameof(AddMenuItem));
        group.MapPut("{id}", UpdateRestaurant).WithName(nameof(UpdateRestaurant));
        group.MapDelete("{id}", DeleteRestaurant).WithName(nameof(DeleteRestaurant));
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
    
    private static async Task<IResult> CreateRestaurant(CreateRestaurantRequest request, IMediator mediator)
    {
        var result = await mediator.Send(new CreateRestaurantCommand(request.Name, request.Street, request.ZipCode, request.Country));

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }
    
    private static async Task<IResult> UpdateRestaurant(Guid id, UpdateRestaurantRequest request, IMediator mediator)
    {
        var result = await mediator.Send(new UpdateRestaurantCommand(id, request.Name, request.Street, request.ZipCode, request.Country));

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }
    
    private static async Task<IResult> DeleteRestaurant(Guid id, IMediator mediator)
    {
        var result = await mediator.Send(new DeleteRestaurantCommand(id));

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }
    
    private static async Task<IResult> AddMenuItem(Guid id, AddMenuItemRequest request, IMediator mediator)
    {
        var result = await mediator.Send(new AddMenuItemCommand(request.Name, request.Price, new RestaurantId(id)));

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }
}