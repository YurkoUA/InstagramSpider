using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using InstagramSpider.Common.Models;

namespace InstagramSpider.PhotoSaver
{
    public class FileSaver
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
                foreach (var item in files)
                {
                    client.DownloadFile(item.Url, $"{_path}\\{item.Name}.jpg");
                }
            }
        }
    }
}
