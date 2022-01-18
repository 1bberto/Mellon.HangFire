using Hangfire;
using Hangfire.Console;
using Hangfire.Server;

namespace Mellon.HangFire.Worker.Jobs
{
    [Queue("crons")]
    public class EmailSender
    {
        
        public async Task SendEmailAsync(
            string clientName,
            string email,
            PerformContext context)
        {
            var progress = context.WriteProgressBar();

            context.WriteLine($"Starting to send email for the client {clientName}");

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

            context.WriteLine($"E-mail to sent to {email}");
        }
    }
}
