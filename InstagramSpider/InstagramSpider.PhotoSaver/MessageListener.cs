using RabbitMQ.Client;
using InstagramSpider.Common.Interfaces;

namespace InstagramSpider.PhotoSaver
{
    public class MessageListener
    {
        private IConnection _connection;
        private IModel _channel;

        private readonly IFileSaver _fileSaver;
        private readonly SaverConfig _config;

        public MessageListener(IFileSaver fileSaver, SaverConfig config)
        {
            _fileSaver = fileSaver;
            _config = config;
        }

        public void Start()
        {
            var factory = new ConnectionFactory { HostName = _config.QueueHost };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            var consumer = new Consumer(_channel, _fileSaver);
            RegisterReceiver(_config.QueueName, consumer);
        }

        public void Stop()
        {
            _channel.Close(200, "Consumer service is stopped");
            _connection.Close();
        }

        public void RegisterReceiver(string receiverType, IBasicConsumer consumer)
        {
            _channel.ExchangeDeclare(exchange: receiverType, type: "direct", durable: true);
            _channel.QueueDeclare(queue: receiverType, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: receiverType, exchange: receiverType, routingKey: string.Empty);
            _channel.BasicConsume(queue: receiverType, autoAck: true, consumer: consumer);
        }
    }
}
