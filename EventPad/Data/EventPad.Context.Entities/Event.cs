using EventPad.Context.Entities.Common;

namespace EventPad.Context.Entities;

public enum EventStatus
{
    Planned,
    Started,
    Completed,
    Moved,
    Cancelled
}

public class Event : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Address { get; set; }
    public EventStatus Status { get; set; }
    public bool Repeat {  get; set; }
    public string? MainPhoto { get; set; }


    public int UserId { get; set; }
    public virtual User User { get; set; }

    public virtual ICollection<EventPhoto>? Photos { get; set; }
}
