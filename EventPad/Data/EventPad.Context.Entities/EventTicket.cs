using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public enum Week
{
    Monday = 0,
    Tuesday = 1, 
    Wednesday = 2,
    Thursday = 3,
    Friday = 4,
    Saturday = 5,
    Sunday = 6
}

public enum TicketStatus
{
    Paid = 0,
    Booked = 1,
    Returned = 2
}

public class EventTicket : BaseEntity
{
    public int EventId { get; set; }
    public virtual Event Event { get; set; }

    public string? Description { get; set; }
    public float? Price { get; set; }
    public string? Address { get; set; }
    public DateTime? DateTime { get; set; }
    public Week? WeekDay { get; set; }
    public bool Private { get; set; }
    public string ArticleNumber { get; set; }
    public TicketStatus Status { get; set; }

    public virtual ICollection<EventVisitor>? Visitors { get; set; }
    public virtual ICollection<PurchaseReceipt>? Purchases { get; set; }
    public virtual ICollection<RefundReceipt>? Refunds { get; set; }
}
