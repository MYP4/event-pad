namespace EventPad.Services.CashoutEventReceipts;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCashoutEventReceiptService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IEventCashoutService, EventCashoutService>();
    }
}
