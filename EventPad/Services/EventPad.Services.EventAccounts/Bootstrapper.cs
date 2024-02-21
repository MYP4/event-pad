﻿namespace EventPad.Services.EventAccounts;

using EventPad.Services.Events;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddEventAccountService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IEventAccountService, EventAccountService>();
    }
}
