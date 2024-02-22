using AutoMapper;
using EventPad.Context;
using EventPad.Context.Entities;
using Microsoft.EntityFrameworkCore;
using EventPad.Common.Validator;
using FluentValidation;

namespace EventPad.Services.CashoutEventReceipts;

public class CreateEventCashoutModel
{
    public Guid EventAccountId { get; set; }
    public Guid UserId { get; set; }

    public string BankAccount { get; set; }
    public float Amount { get; set; }
    public string RKTransactionId { get; set; }
}


public class CreateModelProfile : Profile
{
    public CreateModelProfile()
    {
        CreateMap<CreateEventCashoutModel, CashoutEventReceipt>()
            .BeforeMap<CreateModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EventAccountId, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.Uid, opt => opt.Ignore())
            .AfterMap<CreateModelActions>()
            ;
    }
}


public class CreateModelActions : IMappingAction<CreateEventCashoutModel, CashoutEventReceipt>
{
    public readonly IDbContextFactory<MainDbContext> dbContextFactory;

    public CreateModelActions(IDbContextFactory<MainDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }

    public void Process(CreateEventCashoutModel source, CashoutEventReceipt dest, ResolutionContext context)
    {
        using var db = dbContextFactory.CreateDbContext();

        var eventAccount = db.EventAccounts.FirstOrDefault(x => x.Event.Uid == source.EventAccountId);
        var user = db.Users.FirstOrDefault(x => x.Uid == source.UserId);

        dest.DateTime = DateTime.UtcNow;
        dest.UserId = user.Id;
        dest.EventAccountId = eventAccount.Event.Id;
    }
}


public class CreateEventCashoutModelValidator : AbstractValidator<CreateEventCashoutModel>
{
    public CreateEventCashoutModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User is requered")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.Users.Any(x => x.Uid == id);
                return found;
            }).WithMessage("User not found");

        RuleFor(x => x.EventAccountId)
            .NotEmpty().WithMessage("Event is requered")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.Events.Any(x => x.Uid == id);
                return found;
            }).WithMessage("Event not found");

        RuleFor(x => x.BankAccount)
            .NotEmpty().WithMessage("BankNumber is requered")
            .Length(16).WithMessage("BankNumber length must be 16");

        RuleFor(x => x.Amount)
            .NotEmpty().WithMessage("Amount is requered")
            .GreaterThanOrEqualTo(0).WithMessage("Amount must be greater than or equal to  0");

        RuleFor(x => x.RKTransactionId)
            .NotEmpty().WithMessage("RKTransactionId is requered");
    }
}