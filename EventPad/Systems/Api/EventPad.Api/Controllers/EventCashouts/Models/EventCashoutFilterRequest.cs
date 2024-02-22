using AutoMapper;
using EventPad.Services.CashoutEventReceipts;

namespace EventPad.Api.Controllers.EventCashouts;

public class EventCashoutFilterRequest
{
    public Guid? EventAccount { get; set; }
    public Guid? User { get; set; }
    public string? BankNumber { get; set; }
    public DateTime? DateTime { get; set; }
}


public class EventCashoutFilterProfile : Profile
{
    public EventCashoutFilterProfile()
    {
        CreateMap<EventCashoutFilterRequest, EventCashoutModelFilter>();
    }
}