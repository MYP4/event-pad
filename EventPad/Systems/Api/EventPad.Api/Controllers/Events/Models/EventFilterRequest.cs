using AutoMapper;
using EventPad.Context.Entities;
using EventPad.Services.Events;

namespace EventPad.Api.Controllers.Events;

public class EventFilterRequest
{
    public string? Name { get; set; }
    public float? MinPrice { get; set; }
    public float? MaxPrice { get; set; }
    public EventType? Type { get; set; }
}

public class EventFilterProfile : Profile
{
    public EventFilterProfile()
    {
        CreateMap<EventFilterRequest, EventModelFilter>();
    }
}
