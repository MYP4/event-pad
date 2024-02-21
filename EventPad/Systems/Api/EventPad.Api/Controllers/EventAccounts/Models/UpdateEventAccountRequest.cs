using AutoMapper;
using EventPad.Services.Events;

namespace EventPad.Api.Controllers.EventAccounts;

public class UpdateEventAccountRequest
{
    public float Balance { get; set; }
}

public class EventAccountProfile : Profile
{
    public EventAccountProfile()
    {
        CreateMap<UpdateEventAccountRequest, UpdateEventAccountModel>()
            .ForMember(dest => dest.AccountNumber, opt => opt.Ignore());
    }
}
