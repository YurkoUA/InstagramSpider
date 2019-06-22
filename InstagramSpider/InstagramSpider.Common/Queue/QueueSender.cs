using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using InstagramSpider.Common.Helpers;

namespace InstagramSpider.Common.Queue
{
    public class QueueSender
    {
        private readonly string _queueHost;
        private readonly string _queueName;

        public QueueSender(string queueHost, string queueName)
        {
            _queueHost = queueHost;
            _queueName = queueName;
        }

        public void Push(object data)
        {
            var factory = new ConnectionFactory { HostName = _queueHost };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var json = JsonHelper.Serialize(data);
                var body = Encoding.UTF8.GetBytes(json);

                channel.QueueDeclare(_queueName, false, false, false, null);
                channel.BasicPublish(exchange: string.Empty, routingKey: _queueName, basicProperties: null, body: body);

            }
        }
    }
}
