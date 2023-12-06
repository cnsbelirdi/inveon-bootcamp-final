

using MessageBus;

namespace ShoppingCard.API.RabbitMQ
{
    public interface IRabbitMQCartMessageSender
    {
        void SendMessage(BaseMessage baseMessage, String queueName);
    }
}
