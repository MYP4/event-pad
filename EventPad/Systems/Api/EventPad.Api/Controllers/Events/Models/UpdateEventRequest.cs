using AutoMapper;
using EventPad.Context.Entities;
using EventPad.Services.Events;

namespace EventPad.Api.Controllers.Events;

public class UpdateEventRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public float? Price { get; set; }
    public string? Address { get; set; }
    public EventType? Type { get; set; }
    public string? MainPhoto { get; set; }
}


public class EventUpdateProfile : Profile
{
    public EventUpdateProfile()
    {
        CreateMap<UpdateEventRequest, UpdateEventModel>();
    }
}

