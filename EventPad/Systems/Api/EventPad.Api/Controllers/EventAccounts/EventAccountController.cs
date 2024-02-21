using Asp.Versioning;
using AutoMapper;
using EventPad.Api.Controllers.Events;
using EventPad.Services.Events;
using EventPad.Services.Logger;
using Microsoft.AspNetCore.Mvc;

namespace EventPad.Api.Controllers.EventAccounts;


[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class EventAccountController : ControllerBase
{
    private readonly IAppLogger logger;
    private readonly IEventAccountService eventAccountService;
    private readonly IMapper mapper;

    public EventAccountController(IAppLogger logger, IEventAccountService eventAccountService, IMapper mapper)
    {
        this.logger = logger;
        this.eventAccountService = eventAccountService;
        this.mapper = mapper;
    }


    [HttpGet("")]
    public async Task<IEnumerable<EventAccountResponse>> GetAll()
    {
        var result = await eventAccountService.GetEventAccounts();

        return mapper.Map<IEnumerable<EventAccountResponse>>(result);
    }


    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await eventAccountService.GetEventAccountById(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<EventAccountResponse>(result));
    }


    [HttpPut("{id:Guid}")]
    public async Task<EventAccountResponse> Update([FromRoute] Guid id, UpdateEventAccountRequest request)
    {
        //var model = mapper.Map<UpdateEventModel>(request);
        var result = await eventAccountService.Update(id, mapper.Map<UpdateEventAccountModel>(request));

        return mapper.Map<EventAccountResponse>(result);
    }
}
