using Hangfire.Server;
using Serilog.Events;

namespace Mellon.HangFire.Worker;

internal class PerformContextValue : LogEventPropertyValue
{
    public PerformContext PerformContext { get; set; }

    public override void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null)
    {
        output.Write(PerformContext.BackgroundJob.Id);
    }
}
