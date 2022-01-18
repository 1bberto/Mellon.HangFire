using Hangfire;
using Hangfire.Console;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangFire"));
    config.UseColouredConsoleLogProvider();
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
    config.UseConsole();
});

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console(theme: AnsiConsoleTheme.Code));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();