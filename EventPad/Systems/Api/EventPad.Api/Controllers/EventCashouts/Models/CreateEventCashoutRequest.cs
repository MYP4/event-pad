using AutoMapper;
using EventPad.Services.CashoutEventReceipts;


namespace EventPad.Api.Controllers.EventCashouts;

public class CreateEventCashoutRequest
{
    public Guid EventAccountId { get; set; }
    public Guid UserId { get; set; }

    public string BankAccount { get; set; }
    public float Amount { get; set; }
    public string RKTransactionId { get; set; }
}


public class EventCashoutCreateProfile : Profile
{
    public EventCashoutCreateProfile()
    {
        CreateMap<CreateEventCashoutRequest, CreateEventCashoutModel>();
    }
}