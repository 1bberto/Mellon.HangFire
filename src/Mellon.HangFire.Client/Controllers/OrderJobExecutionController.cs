using Hangfire;
using Mellon.HangFire.Jobs;
using Microsoft.AspNetCore.Mvc;

namespace Mellon.HangFire.Client.Controllers;

[Produces("application/json")]
[Consumes("application/json")]
[ApiController]
[Route("order-jobs")]
public class OrderJobExecutionController : ControllerBase
{
    private readonly IRecurringJobManager _recurringJobManager;

    public OrderJobExecutionController(IRecurringJobManager recurringJobManager)
    {
        _recurringJobManager = recurringJobManager;
    }

    [HttpPost("send-email")]
    public IActionResult SendEmailAsync(SendEmailRequest sendEmailRequest)
    {
        _recurringJobManager.AddOrUpdate<IEmailSender>(
            $"{sendEmailRequest.ClientName}-send-email",
            job => job.SendEmailAsync(
                sendEmailRequest.ClientName,
                sendEmailRequest.Email,
                null),
            sendEmailRequest.CronExpression);

        return Accepted();
    }

    [HttpPost("notify")]
    public IActionResult NotifyAsync(NotifyRequest notifyRequest)
    {
        _recurringJobManager.AddOrUpdate<INotificationProcessing>(
            $"{notifyRequest.ClientName}-notification-processing",
            job => job.NotifyAsync(
                notifyRequest.ClientName,
                null),
            notifyRequest.CronExpression);

        return Accepted();
    }

    [HttpPost("notification-trigger")]
    public IActionResult NotifyTriggerAsync(NotifyRequest notifyRequest)
    {
        _recurringJobManager.AddOrUpdate<INotificationTrigger>(
            $"{notifyRequest.ClientName}-notification-trigger",
            job => job.ExecuteAsync(
                notifyRequest.ClientName,
                null),
            notifyRequest.CronExpression);

        return Accepted();
    }

    public class NotifyRequest
    {
        public string ClientName { get; set; }
        public string CronExpression { get; set; }
    }
    public class SendEmailRequest
    {
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string CronExpression { get; set; }
    }
}

