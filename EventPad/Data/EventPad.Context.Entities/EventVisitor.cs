using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public enum VisitorStatus
{
    Active,
    Ban
}

public class EventVisitor : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int EventTicketId { get; set; }
    public virtual EventTicket EventTicket { get; set; }

    public VisitorStatus Status { get; set; }
}
