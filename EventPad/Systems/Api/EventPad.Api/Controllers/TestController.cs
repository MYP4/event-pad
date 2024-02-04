using Asp.Versioning;
using EventPad.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPad.Api.Controllers;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]

public class TestController : ControllerBase
{
    private readonly IAppLogger logger;

    public TestController(IAppLogger logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    [ApiVersion("1.0")]
    public int Test(int value)
    {
        logger.Debug(this, "Executed {0}, value{1}", "GET:/v1/test/", value);

        return value;
    }

    [HttpGet]
    [ApiVersion("2.0")]
    public int Test(int value, int value2)
    {
        logger.Debug(this, "Executed {0}, value{1}, value{1}", "GET:/v12/test/", value, value2);

        return value * value2;
    }
}
