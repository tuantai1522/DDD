using DDD.Domain;
using DDD.Kitchen.Domain.Aggregate.Restaurant;

namespace DDD.Kitchen.Domain.Aggregate.Ticket;

public sealed class Ticket : Entity, IAggregateRoot, IAuditableEntity
{
    public TicketId Id { get; private init; }

    public TicketState TicketState { get; private set; } = TicketState.CreatePending;
    
    public RestaurantId RestaurantId { get; private init; }
    
    /// <summary>
    /// List of ticket line items in this ticket
    /// </summary>
    private List<TicketLineItem> _ticketLineItems = [];

    public IReadOnlyList<TicketLineItem> TicketLineItems
    {
        get => _ticketLineItems.AsReadOnly(); 
        private set => _ticketLineItems = value.ToList();
    }
    
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; init; }
    
    public DateTime UpdatedAt { get; set; }
    public string? UpdatedBy { get; private set; }
    
    /// <summary>
    /// Time when ticket is accepted
    /// </summary>
    public DateTime AcceptedTime { get; private set; }
    
    /// <summary>
    /// Time when ticket is prepared
    /// </summary>
    public DateTime PreparedTime { get; private set; }
    
    /// <summary>
    /// Time which is used to pick up the ticket
    /// </summary>
    public DateTime PickedUpTime { get; private set; }
    
    /// <summary>
    /// Time when ticket is finished
    /// </summary>
    public DateTime FinishedTime { get; private set; }

    private Ticket()
    {
        
    }
    
    public static Result<Ticket> Create(RestaurantId restaurantId, IReadOnlyList<TicketLineItem> ticketLineItems)
    {
        var ticket = new Ticket()
        {
            Id = TicketId.CreateNew(),
            RestaurantId = restaurantId,
            _ticketLineItems = ticketLineItems.ToList()
        };

        return Result.Success(ticket);
    }

    public void ConfirmCreate()
    {
        if (TicketState == TicketState.CreatePending)
        {
            TicketState = TicketState.AwaitingAcceptance;
        }
    }
    
    public void Accept()
    {
        if (TicketState == TicketState.AwaitingAcceptance)
        {
            AcceptedTime = DateTime.UtcNow;
            TicketState = TicketState.Accepted;
        }
    }
    
    public void Cancel()
    {
        if (TicketState == TicketState.AwaitingAcceptance)
        {
            TicketState = TicketState.Cancelled;
        }
    }
    
    public void Prepare()
    {
        if (TicketState == TicketState.Accepted)
        {
            PreparedTime = DateTime.UtcNow;
            TicketState = TicketState.Preparing;
        }
    }
    
    public void PickUp()
    {
        if (TicketState == TicketState.Preparing)
        {
            PickedUpTime = DateTime.UtcNow;
            TicketState = TicketState.PickedUp;
        }
    }
    
    public void Finish()
    {
        if (TicketState == TicketState.PickedUp)
        {
            FinishedTime = DateTime.UtcNow;
            TicketState = TicketState.Finished;
        }
    }
    
    public double CountTotalPrice() => TicketLineItems.Sum(item => item.Price * item.Quantity);

}