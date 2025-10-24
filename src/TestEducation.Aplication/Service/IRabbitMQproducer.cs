using TestEducation.Aplication.Models;

namespace TestEducation.Aplication.Service
{
    public interface IRabbitMQproducer
    {
        void SedMessage(OrderCreatedDto createdDto);
    }
}
