using Asp.Versioning;
using EventPad.Services.Events;
using EventPad.Services.Logger;
using Microsoft.AspNetCore.Mvc;

namespace EventPad.Api.Controllers.Events;


[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class EventController : ControllerBase
{
    private readonly IAppLogger logger;
    private readonly IEventService eventService;


    public EventController(IAppLogger logger, IEventService eventService)
    {
        this.logger = logger;
        this.eventService = eventService;
    }

    [HttpGet("")]
    public async Task<IEnumerable<EventModel>> GetAll()
    {
        return await eventService.GetAll();
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await eventService.GetById(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<EventModel> Create(CreateModel request)
    {
        return await eventService.Create(request);
    }

    [HttpPut("{id:Guid}")]
    public async Task Update([FromRoute] Guid id, UpdateModel request)
    {
        await eventService.Update(id, request);
    }

    [HttpDelete("{id:Guid}")]
    public async Task Delete([FromRoute] Guid id)
    {
        await eventService.Delete(id);
    }
}




