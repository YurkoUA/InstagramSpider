using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramSpider.Common;
using InstagramSpider.Common.Models;
using InstagramSpider.Common.Queue;

namespace InstagramSpider.Scraper
{
    public class ScraperClient
    {
        private readonly ScraperConfig _config;
        private readonly QueueSender _queue;
        private readonly InstagramClient _instagram;

        public ScraperClient(ScraperConfig config)
        {
            _config = config;
            _queue = new QueueSender(config.QueueHost, config.QueueName);
            _instagram = new InstagramClient();
        }

        public async Task Start()
        {
            var profile = await _instagram.GetProfile(_config.UserName);
            var user = profile?.Users?.FirstOrDefault()?.User;

            if (user == null)
            {
                throw new Exception("Profile is not found.");
            }

            Console.WriteLine($"User {user.UserName} has {user.Media.Count} photos/videos.");

            var files = user.Media.Media
                .Where(i => !i.Node.IsVideo)
                .Select(i => new FileModel
                {
                    Url = i.Node.Url,
                    Name = $"{user.UserName}\\{user.UserName}_{i.Node.Id }"
                }).ToList();

            files.Add(new FileModel
            {
                Name = user.UserName,
                Url = user.ProfilePictureUrl
            });

            _queue.Push(files);

            Console.WriteLine($"{files.Count} images pushed to queue.");
        }
    }
}
