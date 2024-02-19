using EventPad.Context.Entities;

namespace EventPad.Api.Controllers.Events;

public class EventFilterRequest
{
    public string? Name { get; set; }
    public float? MinPrice { get; set; }
    public float? MaxPrice { get; set; }
    public EventType? Type { get; set; }
}
