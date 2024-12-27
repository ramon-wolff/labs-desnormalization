using MassTransit;

namespace Labs.Cache.API.Application.Services.Messaging
{
    public class MessagingService : IMessagingService
    {
        private readonly IBus _bus;

        public MessagingService(IBus bus)
        {
            _bus = bus;
        }

        public async void SendMessage<T>(T message, string rabbitMqUri)
        {
            Uri uri = new(rabbitMqUri);

            var endPoint = _bus.GetSendEndpoint(uri);

            await endPoint.Result.Send(message!);
        }
    }
}
