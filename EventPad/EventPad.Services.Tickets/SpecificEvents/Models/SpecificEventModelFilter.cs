using EventPad.Context.Entities;

namespace EventPad.Services.Specific;

public class SpecificEventModelFilter
{
    public float? Price { get; set; }
    public string? Address { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateTime? DateTime { get; set; }
    public bool? Private { get; set; }
    public EventStatus? Status { get; set; }
}
