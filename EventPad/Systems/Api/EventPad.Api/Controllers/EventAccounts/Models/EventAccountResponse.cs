using AutoMapper;
using EventPad.Services.Events;

namespace EventPad.Api.Controllers.EventAccounts;

public class EventAccountResponse
{
    public Guid Id { get; set; }

    public string AccountNumber { get; set; }
    public float Balance { get; set; }
}


public class EventResponceProfile : Profile
{
    public EventResponceProfile()
    {
        CreateMap<EventAccountModel, EventAccountResponse>();
    }
}