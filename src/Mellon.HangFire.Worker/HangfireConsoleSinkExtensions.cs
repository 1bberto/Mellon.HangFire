using Hangfire.Server;
using Serilog;

namespace Mellon.HangFire.Worker;

public static class HangfireConsoleSinkExtensions
{
    public static Serilog.ILogger CreateLoggerForPerformContext<T>(this PerformContext context)
    {
        return Log.ForContext<T>()
            .ForContext(new HangfireConsoleSerilogEnricher { PerformContext = context });
    }
}