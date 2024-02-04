using EventPad.Api;
using EventPad.Api.Configuration;
using EventPad.Common.Settings;
using EventPad.Services.Logger;
using EventPad.Services.Settings;

var builder = WebApplication.CreateBuilder(args);

var mainSettings = Settings.Load<MainSettings>("Main");
var logSettings = Settings.Load<LogSettings>("Log");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger(mainSettings, logSettings);
builder.Services.AddHttpContextAccessor();

builder.Services.AddAppAutoMappers();
builder.Services.AddAppValidator();
builder.Services.AddAppCors();
builder.Services.AddAppControllerAndViews();
builder.Services.AddAppHealthChecks();
builder.Services.AddAppVersioning();
builder.Services.AddAppSwagger(mainSettings, swaggerSettings);

builder.Services.RegisterServices(builder.Configuration);



var app = builder.Build();

app.UseAppSwagger();

app.UseAppHealthChecks();
app.UseAppCors();
app.UseAppControllerAndViews();

var logger = app.Services.GetRequiredService<IAppLogger>();

logger.Information("The EventPad API was started");

app.Run();

logger.Information("The EventPad API was stopped");
