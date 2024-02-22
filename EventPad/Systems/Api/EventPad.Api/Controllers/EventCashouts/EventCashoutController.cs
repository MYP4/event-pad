using Asp.Versioning;
using AutoMapper;
using EventPad.Api.Controllers.Events;
using EventPad.Services.CashoutEventReceipts;
using EventPad.Services.Logger;
using Microsoft.AspNetCore.Mvc;

namespace EventPad.Api.Controllers.EventCashouts;


[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class EventCashoutController : ControllerBase
{
    private readonly IAppLogger logger;
    private readonly IEventCashoutService eventCashoutService;
    private readonly IMapper mapper;

    public EventCashoutController(IAppLogger logger, IEventCashoutService eventCashoutService, IMapper mapper)
    {
        this.logger = logger;
        this.eventCashoutService = eventCashoutService;
        this.mapper = mapper;
    }


    [HttpGet("")]
    public async Task<IEnumerable<EventCashoutResponse>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] EventCashoutFilterRequest filter = null)
    {
        var result = await eventCashoutService.GetCashoutReceipts(page, pageSize, mapper.Map<EventCashoutModelFilter>(filter));

        return mapper.Map<IEnumerable<EventCashoutResponse>>(result);
    }


    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await eventCashoutService.GetById(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<EventCashoutResponse>(result));
    }


    [HttpPost("")]
    public async Task<EventCashoutResponse> Create(CreateEventCashoutRequest request)
    {
        var result = await eventCashoutService.Cashout(mapper.Map<CreateEventCashoutModel>(request));

        return mapper.Map<EventCashoutResponse>(result);
    }
}
