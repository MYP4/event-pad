using AutoMapper;
using EventPad.Context;
using EventPad.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Services.Events;

public class CreateEventModel
{
    public Guid AdminId { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public EventType Type { get; set; }
    public string? MainPhoto { get; set; }
    public IEnumerable<string> Photos { get; set; }
}


public class CreateModelProfile : Profile
{
    public CreateModelProfile()
    {
        CreateMap<CreateEventModel, Event>()
            .ForMember(dest => dest.AdminId, opt => opt.Ignore())
            .ForMember(dest => dest.Photos, opt => opt.Ignore())
            .AfterMap<CreateModelActions>();
    }
}

public class CreateModelActions : IMappingAction<CreateEventModel, Event>
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;

    public CreateModelActions(IDbContextFactory<MainDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }

    public void Process(CreateEventModel source, Event dest, ResolutionContext context)
    {
        using var db = dbContextFactory.CreateDbContext();

        var author = db.Users.FirstOrDefault(x => x.Uid == source.AdminId);

        dest.AdminId = author.Id;
    }
}

public class CreateEventModelValidator : AbstractValidator<CreateEventModel>
{
    public CreateEventModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(5).WithMessage("Minimal length is 5")
            .MaximumLength(100).WithMessage("Maxomal length is 100");

        RuleFor(x => x.AdminId)
            .NotEmpty().WithMessage("Admin is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.Users.Any(a => a.Uid == id);
                return found;
            }).WithMessage("Admin not found");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Minimal price is 0");

        RuleFor(x => x.Address)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");
    }
}