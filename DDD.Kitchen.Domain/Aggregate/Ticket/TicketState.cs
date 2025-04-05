namespace DDD.Kitchen.Domain.Aggregate.Ticket;

public enum TicketState
{
    CreatePending = 0,
    AwaitingAcceptance = 1,
    Accepted = 2,
    Cancelled = 3,
    Preparing = 4,
    PickedUp = 5,
    Finished = 6,
}