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
            try
            {
                var file = Environment.CurrentDirectory + "\\scraper-config.json";
                var config = JsonHelper.DeserializeFile<ScraperConfig>(file);
                var scraper = new ScraperClient(config);

                var scraperTask = scraper.Start();
                scraperTask.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Scraper is stopped.");
                Console.ReadKey();
            }
        }
    }
}
