using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramSpider.Common.Helpers;

namespace InstagramSpider.Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Task scraperTask = null;

            try
            {
                var file = Environment.CurrentDirectory + "\\scraper-config.json";
                var config = JsonHelper.DeserializeFile<ScraperConfig>(file);
                var scraper = new ScraperClient(config);

                scraperTask = scraper.Start();
                Console.WriteLine("Scraper is working.");
                scraperTask.Wait();
            }
            catch (Exception ex)
            {
                var except = scraperTask.IsFaulted ? scraperTask.Exception : ex;
                Console.WriteLine(except.Message);
            }
            finally
            {
                Console.WriteLine("Scraper is stopped.");
                Console.ReadKey();
            }
        }
    }
}
