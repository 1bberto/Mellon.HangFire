using Hangfire.Console;
using Hangfire.Server;
using Mellon.HangFire.Jobs;

namespace Mellon.HangFire.Worker.Jobs;

public class NotificationProcessing : INotificationProcessing
{
    private readonly TenantContext _jobContext;

    public NotificationProcessing(IServiceProvider serviceProvider)
    {
        _jobContext = serviceProvider.GetRequiredService<TenantContext>();
    }

    public async Task NotifyAsync(
        string clientName,
        PerformContext context)
    {
        var progress = context.WriteProgressBar();

        context.WriteLine($"Notifying the client {_jobContext.ClientName}");

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

        context.WriteLine($"the client {_jobContext.ClientName} was notified");
    }
}
