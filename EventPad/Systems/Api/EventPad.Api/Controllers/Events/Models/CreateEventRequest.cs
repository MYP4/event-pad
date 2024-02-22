using AutoMapper;
using EventPad.Context.Entities;
using EventPad.Services.Events;


namespace EventPad.Api.Controllers.Events;

public class CreateEventRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public EventStatus Status { get; set; }
    public EventType Repeat { get; set; }
    public string MainPhoto { get; set; }

    public Guid AdminId { get; set; }
    public string AdminName { get; set; }
}


public class EventCreateProfile : Profile
{
    public EventCreateProfile()
    {
        CreateMap<CreateEventRequest, CreateEventModel>();
    }
}


