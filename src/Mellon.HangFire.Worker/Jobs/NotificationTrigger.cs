using Hangfire.Console;
using Hangfire.Server;
using Mellon.HangFire.Jobs;

namespace Mellon.HangFire.Worker.Jobs;

public class NotificationTrigger : INotificationTrigger
{
    private readonly TenantContext _jobContext;

    public NotificationTrigger(
        TenantContext jobContext)
    {
        _jobContext = jobContext;
    }

    public async Task ExecuteAsync(
        string clientName,
        PerformContext context)
    {
        _jobContext.SetClient(clientName);

        var logger = context.CreateLoggerForPerformContext<EmailSender>();

        var progress = context.WriteProgressBar();

        logger.Warning($"Starting to send notification for the client {_jobContext.ClientName}");

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

        logger.Warning($"Notification to {_jobContext.ClientName}");
    }
}
