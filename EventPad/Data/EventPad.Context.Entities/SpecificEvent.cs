using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public class SpecificEvent : BaseEntity
{
    public int EventId { get; set; }
    public virtual Event Event { get; set; }

    public string? Description { get; set; }
    public float? Price { get; set; }
    public string? Address { get; set; }
    public DateTime? DateTime { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public bool Private { get; set; }
    public string ArticleNumber { get; set; }
    public EventStatus Status { get; set; }

    public virtual ICollection<EventTicket>? Tickets { get; set; }
    public virtual ICollection<PurchaseReceipt>? Purchases { get; set; }
    public virtual ICollection<RefundReceipt>? Refunds { get; set; }
}
