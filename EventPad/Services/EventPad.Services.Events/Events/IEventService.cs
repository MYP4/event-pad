namespace EventPad.Services.Events;

public interface IEventService
{
    Task<IEnumerable<EventModel>> GetAll();
    Task<EventModel> GetById(Guid id);
    Task<EventModel> Create(CreateModel model);
    Task Update(Guid id, UpdateModel model);
    Task Delete(Guid id);
}
