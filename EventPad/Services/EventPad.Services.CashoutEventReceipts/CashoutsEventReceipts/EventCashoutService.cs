
using AutoMapper;
using EventPad.Common.Exceptions;
using EventPad.Common.Validator;
using EventPad.Context;
using EventPad.Context.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EventPad.Services.CashoutEventReceipts;

public class EventCashoutService : IEventCashoutService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<CreateEventCashoutModel> createModelValidator;

    public EventCashoutService(IDbContextFactory<MainDbContext> dbContextFactory,
        IMapper mapper,
        IModelValidator<CreateEventCashoutModel> createModelValidator)

    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.createModelValidator = createModelValidator;
    }


    public async Task<IEnumerable<EventCashoutModel>> GetCashoutReceipts(int page = 1, int pageSize = 10, EventCashoutModelFilter filter = null)
    {
        var user = filter?.User;
        var eventAccount = filter?.EventAccount;
        var bankNumber = filter?.BankNumber;
        var dateTime = filter?.DateTime;

        using var context = await dbContextFactory.CreateDbContextAsync();

        var receipts = context.CashoutEventReceipts.AsQueryable();

        if (user != null)
        {
            receipts = receipts.Where(e => e.User.Uid == user);
        }

        if (eventAccount != null)
        {
            receipts = receipts.Where(e => e.Account.Event.Uid == eventAccount);
        }

        if (bankNumber != null)
        {
            receipts = receipts.Where(e => e.BankAccount == bankNumber);
        }

        if (dateTime != null)
        {
            receipts = receipts.Where(e => e.DateTime == dateTime);
        }

        receipts = receipts.Skip((page - 1) * pageSize).Take(pageSize);

        var receiptList = await receipts.ToListAsync();

        var result = mapper.Map<IEnumerable<EventCashoutModel>>(receiptList);

        return result;
    }

    public async Task<EventCashoutModel> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var receipt = await context.CashoutEventReceipts.FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<EventCashoutModel>(receipt);

        return result;
    }

    public async Task<EventCashoutModel> Cashout(CreateEventCashoutModel model)
    {
        await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var receipt = mapper.Map<CashoutEventReceipt>(model);

        receipt.Uid = Guid.NewGuid();

        var eventAccount = context.EventAccounts.FirstOrDefault(x => x.Event.Id == receipt.EventAccountId);

        var balance = eventAccount.Balance;
        var amount = receipt.Amount;

        if (amount > balance)
        {
            throw new ProcessException("The Amount must be less than or equal to the Balance");
        }

        eventAccount.Balance = balance - amount;

        context.EventAccounts.Update(eventAccount);

        await context.CashoutEventReceipts.AddAsync(receipt);

        await context.SaveChangesAsync();

        return mapper.Map<EventCashoutModel>(receipt);
    }
}


