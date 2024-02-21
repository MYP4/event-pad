using AutoMapper;
using EventPad.Context.Entities;
using FluentValidation;

namespace EventPad.Services.Events;

public class UpdateEventAccountModel
{
    public string AccountNumber { get; set; }
    public float Balance { get; set; }
}


public class UpdateEventAccountModelProfile : Profile
{
    public UpdateEventAccountModelProfile()
    {
        CreateMap<UpdateEventAccountModel, EventAccount>();
    }
}

public class UpdateEventAccountModelValidator : AbstractValidator<UpdateEventAccountModel>
{
    public UpdateEventAccountModelValidator()
    {
        RuleFor(x => x.AccountNumber)
            .NotEmpty().WithMessage("AccountNumber is required")
            .Length(16).WithMessage("AccountNumber length must be 16");


        RuleFor(x => x.Balance)
            .GreaterThanOrEqualTo(0).WithMessage("Balance must be greater than or equal to  0");
    }
}