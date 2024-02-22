namespace EventPad.Services.CashoutEventReceipts;

public interface IEventCashoutService
{
    Task<IEnumerable<EventCashoutModel>> GetCashoutReceipts(int page = 1, int pageSize = 10, EventCashoutModelFilter filter = null);
    Task<EventCashoutModel> GetById(Guid id);
    Task<EventCashoutModel> Cashout(CreateEventCashoutModel model);
}
