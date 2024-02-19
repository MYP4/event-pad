namespace EventPad.Services.Events;

public interface IEventService
{
    Task<IEnumerable<EventModel>> GetEvents(int page = 1, int pageSize = 10, EventModelFilter filter = null);
    Task<EventModel> GetById(Guid id);
    Task<EventModel> Create(CreateEventModel model);
    Task Update(Guid id, UpdateEventModel model);
    Task Delete(Guid id);
}
