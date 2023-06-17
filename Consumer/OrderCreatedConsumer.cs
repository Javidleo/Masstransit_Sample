using Contract;
using MassTransit;
using Newtonsoft.Json;

namespace Consumer;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    public Task Consume(ConsumeContext<OrderCreated> context)
    {

        var jsonResult = JsonConvert.SerializeObject(context.Message);

        var previousColor = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine(jsonResult);

        Console.ForegroundColor = previousColor;

        return Task.CompletedTask;
    }
}
