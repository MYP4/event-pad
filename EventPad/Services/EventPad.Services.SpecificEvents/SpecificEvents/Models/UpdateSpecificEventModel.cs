using AutoMapper;
using EventPad.Context;
using EventPad.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Services.Specific;

public class UpdateSpecificEventModel
{
    public string? Description { get; set; }
    public float? Price { get; set; }
    public string? Address { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateTime? DateTime { get; set; }
    public bool? Private { get; set; }
    public EventStatus? Status { get; set; }
}


public class UpdateModelProfile : Profile
{
    public UpdateModelProfile()
    {
        CreateMap<UpdateSpecificEventModel, SpecificEvent>();
    }
}

public class UpdateModelValidator : AbstractValidator<UpdateSpecificEventModel>
{
    public UpdateModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        using var context = contextFactory.CreateDbContext();

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Minimal price is 0");

        RuleFor(x => x.Address)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");
    }
}