namespace Mellon.HangFire.Worker;

public class TenantContext
{
    public string ClientName { get; private set; }

    public void SetClient(string clientName) => ClientName = clientName;
}
