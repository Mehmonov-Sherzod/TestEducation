using Microsoft.AspNetCore.Mvc;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Service;

namespace TestEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRabbitMQproducer _producer;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IRabbitMQproducer producer, ILogger<OrderController> logger)
        {
            _producer = producer;
            _logger = logger;
        }

        [HttpPost("send")]
        public IActionResult Send([FromBody] OrderCreatedDto createdDto)
        {
            try
            {
                _producer.SedMessage(createdDto);
                return Ok("Xabar RabbitMQ ga yuborildi.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Xabar yuborishda xatolik");
                return StatusCode(500, "Xatolik yuz berdi");
            }
        }
    }
}
