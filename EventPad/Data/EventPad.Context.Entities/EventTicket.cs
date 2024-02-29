using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;


public class EventTicket : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int EventTicketId { get; set; }
    public virtual SpecificEvent SpecificEvent { get; set; }

    public TicketStatus Status { get; set; }
}
