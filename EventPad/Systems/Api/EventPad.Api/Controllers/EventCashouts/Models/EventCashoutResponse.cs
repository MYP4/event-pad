using AutoMapper;
using EventPad.Services.CashoutEventReceipts;


namespace EventPad.Api.Controllers.EventCashouts;

public class EventCashoutResponse
{
    public Guid Id { get; set; }
    public Guid EventAccountId { get; set; }
    public Guid UserId { get; set; }

    public string BankAccount { get; set; }
    public float Amount { get; set; }
    public DateTime DateTime { get; set; }
    public string RKTransactionId { get; set; }
}


public class EventCashoutResponseProfile : Profile
{
    public EventCashoutResponseProfile()
    {
        CreateMap<EventCashoutModel, EventCashoutResponse>();
    }
}