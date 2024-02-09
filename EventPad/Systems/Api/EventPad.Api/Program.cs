using EventPad.Api;
using EventPad.Api.Configuration;
using EventPad.Common.Settings;
using EventPad.Services.Logger;
using EventPad.Services.Settings;
using EventPad.Context;

var builder = WebApplication.CreateBuilder(args);

var mainSettings = Settings.Load<MainSettings>("Main");
var logSettings = Settings.Load<LogSettings>("Log");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger(mainSettings, logSettings);

var services = builder.Services;

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppAutoMappers();

services.AddAppValidator();

services.AddAppCors();

services.AddAppControllerAndViews();

services.AddAppHealthChecks();

services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings);

services.RegisterServices(builder.Configuration);



var app = builder.Build();

app.UseAppSwagger();

app.UseAppHealthChecks();
app.UseAppCors();
app.UseAppControllerAndViews();

var logger = app.Services.GetRequiredService<IAppLogger>();

logger.Information("The EventPad API was started");

app.Run();

logger.Information("The EventPad API was stopped");
