namespace Mellon.HangFire.Worker;

public class SomeNiceService
{
    private readonly TenantContext _tenantContext;
    private Serilog.ILogger _logger;

    public SomeNiceService(TenantContext tenantContext)
    {
        _tenantContext = tenantContext;
    }

    public void SetLogger(Serilog.ILogger logger) => _logger = logger;

    public void Execute()
    {
        _logger.Information($"Executing {nameof(SomeNiceService)} for {_tenantContext.ClientName}");
    }
}
