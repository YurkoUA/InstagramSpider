using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using InstagramSpider.Common.Helpers;
using InstagramSpider.Common.Models;
using InstagramSpider.Common.Interfaces;

namespace InstagramSpider.PhotoSaver
{
    public class Consumer : EventingBasicConsumer
    {
        private readonly IFileSaver _fileSaver;

        public Consumer(IModel model, IFileSaver fileSaver) : base(model)
        {
            _fileSaver = fileSaver;
            Received += OnReceived;
        }

        private void OnReceived(object sender, BasicDeliverEventArgs e)
        {
            if (e?.Body?.Length == 0)
            {
                return;
            }

            var json = Encoding.UTF8.GetString(e.Body);
            var images = JsonHelper.Deserialize<FileModel[]>(json);

            Console.WriteLine($"{images.Count()} images received.");

            _fileSaver.Save(images);
        }
    }
}
