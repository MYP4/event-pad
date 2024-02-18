using EventPad.Context.Entities;

namespace EventPad.Services.Events;

public class CreateModel
{
    public Guid AdminId { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public EventType Type { get; set; }
    public string? MainPhoto { get; set; }
    public IEnumerable<string> Photos { get; set; }
}
