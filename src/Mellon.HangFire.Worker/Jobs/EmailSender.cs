using Hangfire;
using Hangfire.Console;
using Hangfire.Server;
using Mellon.HangFire.Jobs;

namespace Mellon.HangFire.Worker.Jobs
{
    [Queue("crons")]
    public class EmailSender: IEmailSender
    {
        private readonly SomeNiceService _someNiceService;
        private readonly AnotherNiceService _anotherNiceService;
        private readonly TenantContext _jobContext;

        public EmailSender(
            SomeNiceService someNiceService,
            AnotherNiceService anotherNiceService,
            TenantContext jobContext)
        {
            _someNiceService = someNiceService;
            _anotherNiceService = anotherNiceService;
            _jobContext = jobContext;
        }
        
        public async Task SendEmailAsync(
            string clientName,
            string email,
            PerformContext context)
        {
            _jobContext.SetClient(clientName);

            var logger = context.CreateLoggerForPerformContext<EmailSender>();

            _someNiceService.SetLogger(logger);

            _anotherNiceService.SetLogger(logger);

            _someNiceService.Execute();

            _anotherNiceService.Execute();

            var progress = context.WriteProgressBar();

            logger.Warning($"Starting to send email for the client {_jobContext.ClientName}");

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

            logger.Debug($"E-mail to sent to {_jobContext.ClientName}");

            logger.Error($"E-mail to not sent to {_jobContext.ClientName}");
        }
    }
}
