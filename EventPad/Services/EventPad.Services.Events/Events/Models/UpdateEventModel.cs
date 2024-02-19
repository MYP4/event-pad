using AutoMapper;
using EventPad.Context.Entities;
using FluentValidation;

namespace EventPad.Services.Events;

public class UpdateEventModel
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public EventType Type { get; set; }
    public string? MainPhoto { get; set; }
    public IEnumerable<string> Photos { get; set; }
}


public class UpdateModelProfile : Profile
{
    public UpdateModelProfile()
    {
        CreateMap<UpdateEventModel, Event>();
    }
}

//public class UpdateModelValidator : AbstractValidator<UpdateEventModel>
//{
//    public UpdateModelValidator()
//    {
//        RuleFor(x => x.Name);

//        RuleFor(x => x.Description)
//            .MaximumLength(1000).WithMessage("Maximum length is 1000");
//    }
//}