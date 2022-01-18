using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;

namespace Mellon.HangFire.Worker.Filters;

public class ClientNameAttribute : JobFilterAttribute, IApplyStateFilter
{
    private const string CLIENT_NAME = "ClientName";
    private readonly TenantContext _jobContext;

    public ClientNameAttribute(IServiceProvider serviceProvider)
    {
        _jobContext = serviceProvider.GetRequiredService<TenantContext>();
    }

    public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
    {
        if (context.NewState is EnqueuedState)
        {
            var clientName = SerializationHelper.Deserialize<string>(
                    context.Connection.GetJobParameter(
                    context.BackgroundJob.Id,
                    CLIENT_NAME));

            if (clientName is null)
            {
                context.Connection.SetJobParameter(
                    context.BackgroundJob.Id,
                    CLIENT_NAME,
                    SerializationHelper.Serialize(context.Job.Args[0]));

                clientName = SerializationHelper.Deserialize<string>(
                    context.Connection.GetJobParameter(
                    context.BackgroundJob.Id,            
                    CLIENT_NAME));                
            }

            _jobContext.SetClient(clientName);
        }
    }

    public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
    {
        // Method intentionally left empty.
    }
}

