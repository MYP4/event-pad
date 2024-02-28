
namespace EventPad.Services.Tickets;

public class TicketService : ITicketService
{
    public Task<TicketModel> Create(CreateTicketModel model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TicketModel> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TicketModel>> GetEvents(int page = 1, int pageSize = 10, TicketModelFilter filter = null)
    {
        throw new NotImplementedException();
    }

    public Task<TicketModel> Update(Guid id, UpdateTicketModel model)
    {
        throw new NotImplementedException();
    }
}
