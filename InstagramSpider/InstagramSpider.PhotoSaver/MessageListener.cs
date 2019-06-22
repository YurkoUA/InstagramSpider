using RabbitMQ.Client;

namespace InstagramSpider.PhotoSaver
{
    public static class MessageListener
    {
        private static IConnection connection;
        private static IModel channel;

        public static void Start(FileSaver fileSaver)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            var consumer = new Consumer(channel, fileSaver);
            RegisterReceiver("ImagesQueue", consumer);
        }

        public static void Stop()
        {
            channel.Close(200, "Consumer service is stopped");
            connection.Close();
        }

        public static void RegisterReceiver(string receiverType, IBasicConsumer consumer)
        {
            channel.ExchangeDeclare(exchange: receiverType, type: "direct", durable: true);
            channel.QueueDeclare(queue: receiverType, durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(queue: receiverType, exchange: receiverType, routingKey: string.Empty);
            channel.BasicConsume(queue: receiverType, autoAck: true, consumer: consumer);
        }
    }
}
