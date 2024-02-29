﻿
using AutoMapper;
using EventPad.Common.Exceptions;
using EventPad.Common.Validator;
using EventPad.Context;
using EventPad.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Services.Specific;

public class SpecificEventService : ISpecificEventService
{

    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<CreateSpecificEventModel> createModelValidator;
    private readonly IModelValidator<UpdateSpecificEventModel> updateModelValidator;

    public SpecificEventService(IDbContextFactory<MainDbContext> dbContextFactory,
        IMapper mapper,
        IModelValidator<CreateSpecificEventModel> createModelValidator,
        IModelValidator<UpdateSpecificEventModel> updateModelValidator)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.createModelValidator = createModelValidator;
        this.updateModelValidator = updateModelValidator;
    }


    public async Task<IEnumerable<SpecificEventModel>> GetSpecificEvents(int page = 1, int pageSize = 10, SpecificEventModelFilter filter = null)
    {
        var price = filter?.Price;
        var address = filter?.Address;
        var day = filter?.DayOfWeek;
        var dateTime = filter?.DateTime;
        var _private = filter?.Private;
        var status = filter?.Status;

        using var context = await dbContextFactory.CreateDbContextAsync();

        var events = context.SpecificEvents.AsQueryable();

        if (price != null)
        {
            events = events.Where(x => x.Price == price);
        }
        if (address != null)
        {
            events = events.Where(x => x.Address == address);
        }
        if (day != null)
        {
            events = events.Where(x => x.DayOfWeek == day);
        }
        if (dateTime != null)
        {
            events = events.Where(x => x.DateTime == dateTime);
        }
        if (_private != null)
        {
            events = events.Where(x => x.Private == _private);
        }
        if (status != null)
        {
            events = events.Where(x => x.Status == status);
        }

        events = events.Skip((page - 1) * pageSize).Take(pageSize);

        var eventList = await events.ToListAsync();

        var result = mapper.Map<IEnumerable<SpecificEventModel>>(eventList);

        return result;
    }

    public async Task<SpecificEventModel> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var _event = await context.SpecificEvents.FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<SpecificEventModel>(_event);

        return result;
    }
     
    public async Task<SpecificEventModel> Create(CreateSpecificEventModel model)
    {
        await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var _event = mapper.Map<SpecificEvent>(model);

        _event.Uid = Guid.NewGuid();

        await context.SpecificEvents.AddAsync(_event);

        await context.SaveChangesAsync();

        return mapper.Map<SpecificEventModel>(_event);
    }

    public async Task<SpecificEventModel> Update(Guid id, UpdateSpecificEventModel model)
    {
        await updateModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var _event = await context.SpecificEvents.FirstOrDefaultAsync(x => x.Uid == id);

        _event = mapper.Map(model, _event);

        context.SpecificEvents.Update(_event);

        await context.SaveChangesAsync();

        return mapper.Map<SpecificEventModel>(_event);
    }

    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var _event = await context.SpecificEvents.FirstOrDefaultAsync(x => x.Uid == id);

        if (_event == null)
            throw new ProcessException($"Specific Event (ID = {id}) not found.");

        context.SpecificEvents.Remove(_event);

        await context.SaveChangesAsync();
    }
}
