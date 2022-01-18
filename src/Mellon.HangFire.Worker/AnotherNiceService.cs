namespace Mellon.HangFire.Worker;

public class AnotherNiceService
{
    private readonly TenantContext _tenantContext;
    private Serilog.ILogger _logger;

    public AnotherNiceService(TenantContext tenantContext)
    {
        _tenantContext = tenantContext;
    }
    public void SetLogger(Serilog.ILogger logger) => _logger = logger;

    public void Execute()
    {
        _logger.Information($"Executing {nameof(AnotherNiceService)} for {_tenantContext.ClientName}");
    }
}
