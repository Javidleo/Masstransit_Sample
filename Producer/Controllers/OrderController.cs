using Contract;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Producer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IBus _bus;

    public OrderController(IBus bus)
    {
        _bus = bus;
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderDto dto, CancellationToken ct)
    {
        await _bus.Publish<OrderCreated>(new
        {
            Id = 1,
            dto.ProductName,
            dto.Quantity,
            dto.Price
        }, ct);

        return Ok();
    }
}
