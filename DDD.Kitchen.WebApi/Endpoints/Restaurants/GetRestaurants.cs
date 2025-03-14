using Ardalis.ApiEndpoints;
using DDD.Kitchen.Application.Restaurants.Queries.GetRestaurants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Kitchen.WebApi.Endpoints.Restaurants;

public class GetRestaurants(IMediator mediator) : EndpointBaseAsync
    .WithRequest<GetRestaurantsQuery>
    .WithActionResult
{
    private readonly IMediator _mediator = mediator;
    
    [HttpGet("api/v1/restaurants")]
    public override async Task<ActionResult> HandleAsync(
        [FromQuery] GetRestaurantsQuery request,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var query = new GetRestaurantsQuery();
        
        await _mediator.Send(query, cancellationToken);

        return Ok();
    }
}