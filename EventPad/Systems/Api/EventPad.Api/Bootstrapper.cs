namespace EventPad.Api;

using EventPad.Services.Logger;
using EventPad.Services.Settings;
using EventPad.Context.Seeder;
using EventPad.Services.Events;
using EventPad.Services.EventAccounts;
using EventPad.Services.CashoutEventReceipts;
using EventPad.Services.Specific;

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
            .AddCashoutEventReceiptService()
            .AddSpecificEventService()
            ;

        return services;
    }
}
