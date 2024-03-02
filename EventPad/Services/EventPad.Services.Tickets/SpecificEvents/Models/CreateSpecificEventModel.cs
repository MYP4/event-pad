using AutoMapper;
using EventPad.Context;
using EventPad.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Services.Specific;

public class CreateSpecificEventModel
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
        CreateMap<CreateSpecificEventModel, SpecificEvent>()
            .ForMember(dest => dest.EventId, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.ArticleNumber, opt => opt.Ignore())
            .ForMember(dest => dest.Purchases, opt => opt.Ignore())
            .ForMember(dest => dest.Refunds, opt => opt.Ignore())
            .ForMember(dest => dest.Tickets, opt => opt.Ignore())
            .AfterMap<CreateModelActions>()
            ;
    }
}

public class CreateModelActions : IMappingAction<CreateSpecificEventModel, SpecificEvent>
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly ISpecificEventService ticketService;

    public CreateModelActions(IDbContextFactory<MainDbContext> dbContextFactory, ISpecificEventService ticketService)
    {
        this.dbContextFactory = dbContextFactory;
        this.ticketService = ticketService;
    }

    public void Process(CreateSpecificEventModel sourse, SpecificEvent dest, ResolutionContext context)
    {
        using var db = dbContextFactory.CreateDbContext();
        var _event = db.Events.FirstOrDefault(x => x.Uid == sourse.EventId);

        var article = Guid.NewGuid().ToString().ToUpper().Replace("-", "");


        dest.EventId = _event.Id;
        dest.Status = EventStatus.Planned;
        dest.ArticleNumber = article;
    }
}

public class CreateModelValidator : AbstractValidator<CreateSpecificEventModel>
{
    public CreateModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    { 
        RuleFor(x => x.EventId)
            .NotEmpty().WithMessage("Event is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.Events.Any(a => a.Uid == id);
                return found;
            }).WithMessage("Event not found");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Minimal price is 0");

        RuleFor(x => x.Address)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");

        RuleFor(x => x)
            .Must(model =>
            {
                using var context = contextFactory.CreateDbContext();
                var _event = context.Events.FirstOrDefault(a => a.Uid == model.EventId);
                if (_event.Type == EventType.Single)
                    return true;

                return model.DayOfWeek != null;
            })
            .WithName(nameof(CreateSpecificEventModel.DayOfWeek))
            .WithMessage("Day of week is required");

        RuleFor(x => x)
            .Must(model =>
            {
                using var context = contextFactory.CreateDbContext();
                var _event = context.Events.FirstOrDefault(a => a.Uid == model.EventId);
                if (_event.Type == EventType.Multiple)
                    return true;

                return model.DateTime != null;
            })
            .WithName(nameof(CreateSpecificEventModel.DateTime))
            .WithMessage("DateTime is required");
    }
}