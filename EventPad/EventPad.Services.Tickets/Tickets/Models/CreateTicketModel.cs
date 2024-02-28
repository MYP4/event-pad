using AutoMapper;
using EventPad.Context;
using EventPad.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Services.Tickets;

public class CreateTicketModel
{
    public Guid EventId { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateTime? DateTime { get; set; }
    public bool Private { get; set; }
}


public class CreateModelProfile : Profile
{
    public CreateModelProfile()
    {
        CreateMap<CreateTicketModel, EventTicket>()
            .ForMember(dest => dest.EventId, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.ArticleNumber, opt => opt.Ignore())
            .ForMember(dest => dest.Purchases, opt => opt.Ignore())
            .ForMember(dest => dest.Refunds, opt => opt.Ignore())
            .ForMember(dest => dest.Visitors, opt => opt.Ignore())
            ;
    }
}

public class CreateModelActions : IMappingAction<CreateTicketModel, EventTicket>
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly ITicketService ticketService;

    public CreateModelActions(IDbContextFactory<MainDbContext> dbContextFactory, ITicketService ticketService)
    {
        this.dbContextFactory = dbContextFactory;
        this.ticketService = ticketService;
    }

    public void Process(CreateTicketModel sourse, EventTicket dest, ResolutionContext context)
    {
        using var db = dbContextFactory.CreateDbContext();
        var _event = db.Events.FirstOrDefault(x => x.Uid == sourse.EventId);

        dest.EventId = _event.Id;
        dest.Status = TicketStatus.Free;
    }
}