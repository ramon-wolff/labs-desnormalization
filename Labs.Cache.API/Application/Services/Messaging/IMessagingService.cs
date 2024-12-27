namespace Labs.Cache.API.Application.Services.Messaging
{
    public interface IMessagingService
    {
        void SendMessage<T>(T message, string rabbitMqUri);
    }
}
