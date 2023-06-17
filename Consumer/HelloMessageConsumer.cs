using Contract;
using MassTransit;
using Newtonsoft.Json;

namespace Consumer;

public class HelloMessageConsumer : IConsumer<HelloContract>
{

    public Task Consume(ConsumeContext<HelloContract> context)
    {
        var jsonResult = JsonConvert.SerializeObject(context.Message);

        var previousColor = Console.ForegroundColor;

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine($"its a hello message {jsonResult}");

        Console.ForegroundColor = previousColor;

        return Task.CompletedTask;
    }
}
