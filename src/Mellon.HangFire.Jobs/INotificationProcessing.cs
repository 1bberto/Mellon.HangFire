using Hangfire;
using Hangfire.Server;

namespace Mellon.HangFire.Jobs;

[Queue("trigger")]
public interface INotificationProcessing
{
    Task NotifyAsync(string clientName, PerformContext context);
}
