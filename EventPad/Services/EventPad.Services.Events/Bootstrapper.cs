namespace EventPad.Services.Events;

using EventPad.Services.Events.Events;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddEventService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IEventService, EventService>();
    }
}
