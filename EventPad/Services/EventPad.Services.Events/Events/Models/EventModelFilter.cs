using EventPad.Context.Entities;

namespace EventPad.Services.Events;

public class EventModelFilter
{
    public string? Name { get; set; }
    public float? MinPrice { get; set; }
    public float? MaxPrice { get; set; }
    public EventType? Type { get; set; }
}
