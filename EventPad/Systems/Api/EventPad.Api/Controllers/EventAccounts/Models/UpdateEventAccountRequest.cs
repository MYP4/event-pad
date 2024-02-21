using AutoMapper;
using EventPad.Api.Controllers.Events;
using EventPad.Services.Events;

namespace EventPad.Api.Controllers.EventAccounts;

public class UpdateEventAccountRequest
{
    public string Balance { get; set; }
}

public class EventAccountProfile : Profile
{
    public EventAccountProfile()
    {
        CreateMap<UpdateEventAccountRequest, UpdateEventAccountModel>();
    }
}
