using AutoMapper;
using EventPad.Context;
using EventPad.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Services.Events;

public class EventAccountModel
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; }
    public float Balance { get; set; }
}


public class EventAccountModelProfile : Profile
{
    public EventAccountModelProfile()
    {
        CreateMap<EventAccount, EventAccountModel>()
            .BeforeMap<EventAccountModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            ;
    }
}

public class EventAccountModelActions : IMappingAction<EventAccount, EventAccountModel>
{

    public readonly IDbContextFactory<MainDbContext> dbContextFactory;

    public EventAccountModelActions(IDbContextFactory<MainDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }

    public void Process(EventAccount source, EventAccountModel dest, ResolutionContext context)
    {
        using var db = dbContextFactory.CreateDbContext();

        var model = db.Events.FirstOrDefault(x => x.Id == source.Event.Id);

        dest.Id = model.Uid;
    }
}