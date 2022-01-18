using Hangfire.Console;
using Serilog.Core;
using Serilog.Events;

namespace Mellon.HangFire.Worker;

public class HangfireConsoleSink : ILogEventSink
{
    public void Emit(LogEvent logEvent)
    {
        if (logEvent.Properties.TryGetValue("PerformContext", out var logEventPerformContext))
        {
            var performContext = (logEventPerformContext as PerformContextValue)?.PerformContext;

            performContext?.WriteLine(GetColor(logEvent.Level), logEvent.RenderMessage());
        }

        static ConsoleTextColor GetColor(LogEventLevel level)
        {
            return level switch
            {
                LogEventLevel.Fatal or LogEventLevel.Error => ConsoleTextColor.Red,
                LogEventLevel.Warning => ConsoleTextColor.Yellow,
                LogEventLevel.Information => ConsoleTextColor.White,
                LogEventLevel.Verbose or LogEventLevel.Debug => ConsoleTextColor.Gray,
                _ => throw new ArgumentOutOfRangeException(nameof(level)),
            };
        }
    }
}
