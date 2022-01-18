using Hangfire;

namespace Mellon.HangFire.Worker;

public static class UseFilterExtensions
{
    public static IGlobalConfiguration UseFilterFromServices<TFilter>(
        this IGlobalConfiguration configuration, 
        IServiceProvider services)
    {
        return configuration.UseFilter(services.GetRequiredService<TFilter>());
    }
}

