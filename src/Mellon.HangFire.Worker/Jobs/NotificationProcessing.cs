using Hangfire;
using Hangfire.Console;
using Hangfire.Server;

namespace Mellon.HangFire.Worker.Jobs
{
    [Queue("trigger")]
    public class NotificationProcessing
    {
        public async Task NotifyAsync(
            string clientName,
            PerformContext context)
        {
            var progress = context.WriteProgressBar();

            context.WriteLine($"Notifying the client {clientName}");

            await Task.Delay(10000);

            progress.SetValue(20);

            await Task.Delay(10000);

            progress.SetValue(40);

            await Task.Delay(10000);

            progress.SetValue(60);

            await Task.Delay(10000);

            progress.SetValue(80);

            await Task.Delay(10000);

            progress.SetValue(100);

            context.WriteLine($"the client {clientName}");
        }
    }
}
