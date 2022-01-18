using Hangfire;

namespace Mellon.HangFire.Jobs
{
    [Queue("crons")]
    public interface IEmailSender
    {
        Task SendEmailAsync(string clientName, string email);
    }
}