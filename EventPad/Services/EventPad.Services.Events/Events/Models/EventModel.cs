using EventPad.Context.Entities;

namespace EventPad.Services.Events;

public class EventModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public EventStatus Status { get; set; }
    public EventType Repeat { get; set; }
    public string MainPhoto { get; set; }

    public Guid AdminId { get; set; }
    public string AdminName { get; set; }

    public IEnumerable<string>? Photos { get; set; }
}
