using AutoMapper;
using EventPad.Common.Exceptions;
using EventPad.Context;
using EventPad.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventPad.Services.Events;

public class EventService : IEventService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;

    public EventService(IDbContextFactory<MainDbContext> dbContextFactory, IMapper mapper)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
    }


    public async Task<IEnumerable<EventModel>> GetEvents(int page = 1, int pageSize = 10, EventModelFilter filter = null)
    {
        var name = filter?.Name;
        var minPrice = filter?.MinPrice;
        var maxPrice = filter?.MaxPrice;
        var type = filter?.Type;

        using var context = await dbContextFactory.CreateDbContextAsync();

        var events = context.Events.AsQueryable();

        if (name != null)
        {
            events = events.Where(e => e.Name.ToLower().Contains(name.ToLower()));
        }

        if (maxPrice != null)
        {
            events = events.Where(e => e.Price <= maxPrice);
        }

        if (minPrice != null)
        {
            events = events.Where(e => e.Price >= minPrice);
        }


        if (type != null)
        {
            events = events.Where(e => e.Type == type);
        }

        events = events.Skip((page - 1) * pageSize).Take(pageSize);

        var eventList = await events.ToListAsync();

        var result = mapper.Map<IEnumerable<EventModel>>(eventList);

        return result;
    }

    public async Task<EventModel> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var events = await context.Events.FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<EventModel>(events);

        return result;
    }

    public async Task<EventModel> Create(CreateEventModel model)
    {
        //await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var _event = mapper.Map<Event>(model);

        await context.Events.AddAsync(_event);

        await context.SaveChangesAsync();

        return mapper.Map<EventModel>(_event);
    }

    public async Task Update(Guid id, UpdateEventModel model)
    {
        //await updateModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var _event = await context.Events.Where(x => x.Uid == id).FirstOrDefaultAsync();

        _event = mapper.Map(model, _event);

        context.Events.Update(_event);

        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var _event = await context.Events.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (_event == null)
            throw new ProcessException($"Event (ID = {id}) not found.");

        context.Events.Remove(_event);

        await context.SaveChangesAsync();
    }
}
