using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using InstagramSpider.Common.Helpers;
using InstagramSpider.Common.Interfaces;
using InstagramSpider.Common.Models;

namespace InstagramSpider.PhotoSaver
{
    public class FileSaver : IFileSaver
    {
        private readonly string _path;

        public FileSaver(string path)
        {
            _path = path;
        }

        public void Save(params FileModel[] files)
        {
            using (var client = new WebClient())
            {
                foreach (var item in files.AsParallel())
                {
                    var path = $"{_path}\\{item.Name}.jpg";
                    FileHelper.PrepareDirectory(path);

                    client.DownloadFile(item.Url, path);
                    Console.WriteLine($"Downloaded: {item.Url}");
                }
            }
        }
    }
}
