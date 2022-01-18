using Hangfire;
using Hangfire.Console;
using Mellon.HangFire.Jobs;
using Mellon.HangFire.Worker;
using Mellon.HangFire.Worker.Jobs;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<TenantContext>();
        services.AddScoped<AnotherNiceService>();
        services.AddScoped<SomeNiceService>();

        services.AddHangfireServer(config =>
        {
            config.ServerName = $"Worker-{Guid.NewGuid()}";
            config.Queues = new string[] { "default", "crons", "trigger" };
            config.WorkerCount = 10;
        });

        services.AddHangfire((serviceProvider, config) =>
        {
            config.UseSqlServerStorage(hostContext.Configuration.GetConnectionString("HangFire"));
            config.UseColouredConsoleLogProvider();
            config.UseSimpleAssemblyNameTypeSerializer();
            config.UseRecommendedSerializerSettings();
            config.UseConsole();
        });

        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<INotificationProcessing, NotificationProcessing>();
        services.AddScoped<INotificationTrigger, NotificationTrigger>();
    })
    .Build();

Log.Logger = new LoggerConfiguration().WriteTo.Sink(new HangfireConsoleSink()).CreateLogger();

await host.RunAsync();