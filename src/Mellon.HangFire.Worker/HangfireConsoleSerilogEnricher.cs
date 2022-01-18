using Hangfire.Server;
using Serilog.Core;
using Serilog.Events;

namespace Mellon.HangFire.Worker;

internal class HangfireConsoleSerilogEnricher : ILogEventEnricher
{
    public PerformContext PerformContext { get; set; }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var prop = new LogEventProperty(
            "PerformContext", new PerformContextValue { PerformContext = PerformContext }
        );

        logEvent.AddOrUpdateProperty(prop);
    }
}
