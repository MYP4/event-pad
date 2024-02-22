using AutoMapper;
using EventPad.Context;
using EventPad.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Services.CashoutEventReceipts;

public class EventCashoutModel
{
    public Guid Id { get; set; }
    public Guid EventAccountId { get; set; }
    public Guid UserId { get; set; }

    public string BankAccount { get; set; }
    public float Amount { get; set; }
    public DateTime DateTime { get; set; }
    public string RKTransactionId { get; set; }
}


public class EventCashoutModelProfile : Profile
{
    public EventCashoutModelProfile()
    {
        CreateMap<CashoutEventReceipt, EventCashoutModel>()
            .BeforeMap<EventCashoutModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EventAccountId, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            ;
    }
}


public class EventCashoutModelActions : IMappingAction<CashoutEventReceipt, EventCashoutModel>
{
    public readonly IDbContextFactory<MainDbContext> dbContextFactory;

    public EventCashoutModelActions(IDbContextFactory<MainDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }

    public void Process(CashoutEventReceipt source, EventCashoutModel dest, ResolutionContext context)
    {
        using var db = dbContextFactory.CreateDbContext();

        var model = db.Events.FirstOrDefault(x => x.Id == source.EventAccountId);

        dest.Id = source.Uid;
        dest.UserId = model.Admin.Uid;
        dest.EventAccountId = model.Uid;
    }
}