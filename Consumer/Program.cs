// See https://aka.ms/new-console-template for more information

using Consumer;
using MassTransit;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("order-created-event", i => i.Consumer<OrderCreatedConsumer>());

    cfg.ReceiveEndpoint("hello-message-event", i => i.Consumer<HelloMessageConsumer>());
});

await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("press enter to exit");

    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}