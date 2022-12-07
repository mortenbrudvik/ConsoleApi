using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace console_api;

public class ApiService : IAsyncDisposable
{
    private readonly WebApplication _app;
    private readonly CancellationTokenSource _cts = new();
    private readonly IAppLogger<ApiService>? _logger;

    public ApiService(int port)
    {
        var builder = WebApplication.CreateBuilder( new WebApplicationOptions
        {
            ApplicationName = typeof(ApiService).Assembly.GetName().Name 
        });
        builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        builder.Services.AddControllers();
        _app = builder.Build();
        _app.Urls.Add($"http://localhost:{port}");
        _app.MapControllers();

        _logger = _app.Services.GetService<IAppLogger<ApiService>>();
    }
    
    public async Task Start()
    {
        _app.Lifetime.ApplicationStarted.Register(() => { _logger?.LogInformation("ApiService Started");});
        await _app.StartAsync(_cts.Token);
    }
    public async Task Stop()
    {
        await DisposeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        _cts.Cancel();
        await _app.StopAsync();
    }
}