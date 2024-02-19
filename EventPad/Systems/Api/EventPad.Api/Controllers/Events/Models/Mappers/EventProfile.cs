using AutoMapper;
using EventPad.Services.Events;

namespace EventPad.Api.Controllers.Events;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<CreateEventRequest, CreateEventModel>();
        CreateMap<UpdateEventRequest, UpdateEventModel>();
        CreateMap<EventFilterRequest, EventModelFilter>();
        CreateMap<EventModel, EventResponse>();
    }
}
