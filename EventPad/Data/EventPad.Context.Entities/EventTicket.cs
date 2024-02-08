using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public enum Week
{
    Monday,
    Tuesday, 
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public enum TicketStatus
{
    Paid,
    Booked,
    Returned
}

public class EventTicket : BaseEntity
{
    public int EventId { get; set; }
    public virtual Event Event { get; set; }

    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? Address { get; set; }
    public DateTime? DateTime { get; set; }
    public Week? WeekDay { get; set; }
    public bool Private { get; set; }
    public string ArticleNumber { get; set; }
    public TicketStatus Status { get; set; }
}
