using AutoMapper;
using EventPad.Context;
using EventPad.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Services.Events;

public class EventModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public EventStatus Status { get; set; }
    public EventType Type { get; set; }
    public string MainPhoto { get; set; }

    public Guid AdminId { get; set; }
    public string AdminName { get; set; }

    public IEnumerable<string>? Photos { get; set; }
}


public class EventModelProfile : Profile
{
    public EventModelProfile()
    {
        CreateMap<Event, EventModel>()
            .BeforeMap<EventModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.AdminId, opt => opt.Ignore())
            .ForMember(dest => dest.AdminName, opt => opt.Ignore())
            .ForMember(dest => dest.Photos, opt => opt.Ignore())
            ;
    }
}


public class EventModelActions : IMappingAction<Event, EventModel>
{

    public readonly IDbContextFactory<MainDbContext> dbContextFactory;

    public EventModelActions(IDbContextFactory<MainDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }

    public void Process(Event source, EventModel dest, ResolutionContext context)
    {
        using var db = dbContextFactory.CreateDbContext();

        var model = db.Events.FirstOrDefault(x => x.Id == source.Id);

        dest.Id = model.Uid;
        dest.AdminId = model.Admin.Uid;
        dest.AdminName = model.Admin.FirstName + " " + model.Admin.SecondName;
        dest.Photos = model.Photos?.Select(x => x.Path);
    }
}