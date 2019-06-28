using System;
using InstagramSpider.Common.Helpers;

namespace InstagramSpider.PhotoSaver
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageListener listener = null;

            try
            {
                var file = Environment.CurrentDirectory + "\\saver-config.json";
                var config = JsonHelper.DeserializeFile<SaverConfig>(file);

                listener = new MessageListener(new FileSaver(config.OutputDirectory), config);
                listener.Start();

                Console.WriteLine("Photo Saver is working...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                listener?.Stop();
            }
        }
    }
}
