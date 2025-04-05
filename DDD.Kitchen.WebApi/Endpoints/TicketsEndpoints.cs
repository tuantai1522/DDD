using Carter;
using DDD.Kitchen.Application.Tickets.Commands.CreateTicket;
using DDD.Kitchen.WebApi.Extensions;
using MediatR;

namespace DDD.Kitchen.WebApi.Endpoints;

public class TicketsEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/tickets");
        
        group.MapPost("", CreateTicket).WithName(nameof(CreateTicket));
    }

    private static async Task<IResult> CreateTicket(CreateTicketRequest request, IMediator mediator)
    {
        var result = await mediator.Send(new CreateTicketCommand(request.Tickets));

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }
    
}