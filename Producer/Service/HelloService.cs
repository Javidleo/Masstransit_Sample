using Contract;
using MassTransit;

namespace Producer.Service;

public class HelloService : BackgroundService
{
    private readonly IBus _bus;

    public HelloService(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _bus.Publish<HelloContract>(new
            {
                Name = "hello world"
            });

            await Task.Delay(100000, stoppingToken);
        }
    }
}
