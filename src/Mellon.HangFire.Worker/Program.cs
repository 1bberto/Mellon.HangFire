using Hangfire;
using Hangfire.Console;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHangfireServer(config =>
        {
            config.ServerName = $"Worker-{Guid.NewGuid()}";
            config.Queues = new string[] { "default", "crons", "trigger" };
            config.WorkerCount = 10;
        });

        services.AddHangfire(config =>
        {
            config.UseSqlServerStorage(hostContext.Configuration.GetConnectionString("HangFire"));
            config.UseColouredConsoleLogProvider();
            config.UseSimpleAssemblyNameTypeSerializer();
            config.UseRecommendedSerializerSettings();
            config.UseConsole();
        });
    })
    .Build();

await host.RunAsync();