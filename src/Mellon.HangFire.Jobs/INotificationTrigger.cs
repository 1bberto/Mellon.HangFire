using Hangfire;
using Hangfire.Server;

namespace Mellon.HangFire.Jobs;

[Queue("trigger")]
public interface INotificationTrigger
{
    Task ExecuteAsync(string clientName, PerformContext context);
}
