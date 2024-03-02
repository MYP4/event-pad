namespace EventPad.Services.Specific;

public interface ISpecificEventService
{
    Task<IEnumerable<SpecificEventModel>> GetSpecificEvents(int page = 1, int pageSize = 10, SpecificEventModelFilter filter = null);
    Task<SpecificEventModel> GetById(Guid id);
    Task<SpecificEventModel> Create(CreateSpecificEventModel model);
    Task<SpecificEventModel> Update(Guid id, UpdateSpecificEventModel model);
    Task Delete(Guid id);
}
