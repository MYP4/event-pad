namespace EventPad.Api;

using EventPad.Services.Logger;
using EventPad.Services.Settings;
using EventPad.Context.Seeder;
using EventPad.Services.Events;
using EventPad.Services.EventAccounts;

public static class Bootstrapper
{
    public static IServiceCollection RegisterServices (this IServiceCollection services, IConfiguration configuration = null)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddLogSettings()
            .AddAppLogger()
            .AddDbSeeder()
            .AddEventService()
            .AddEventAccountService()
            ;

        return services;
    }
}
