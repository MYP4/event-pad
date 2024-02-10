using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public enum EventStatus
{
    Planned = 0,
    Started = 1,
    Completed = 2,
    Moved = 3,
    Cancelled = 4
}

public enum EventType
{
    Single = 0,
    Multiple = 1
}

public class Event : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public EventStatus Status { get; set; }
    public EventType Repeat {  get; set; }
    public string? MainPhoto { get; set; }


    public int AdminId { get; set; }
    public virtual User User { get; set; }

    public virtual EventAccount EventAccount { get; set; }

    public virtual ICollection<EventPhoto>? Photos { get; set; }
    public virtual ICollection<EventTicket>? Tickets { get; set; }
}
