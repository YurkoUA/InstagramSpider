using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramSpider.Common.Helpers;

namespace InstagramSpider.PhotoSaver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var file = Environment.CurrentDirectory + "\\saver-config.json";
                var config = JsonHelper.DeserializeFile<SaverConfig>(file);
                MessageListener.Start(new FileSaver(config.OutputDirectory));

                Console.WriteLine("Photo Saver is working...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                MessageListener.Stop();
            }
        }
    }
}
