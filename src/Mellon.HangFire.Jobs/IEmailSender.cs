using Hangfire;
using Hangfire.Server;

namespace Mellon.HangFire.Jobs;

[Queue("crons")]
public interface IEmailSender
{
    Task SendEmailAsync(string clientName, string email, PerformContext context);
}
