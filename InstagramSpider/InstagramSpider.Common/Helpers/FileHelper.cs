using System.IO;

namespace InstagramSpider.Common.Helpers
{
    public static class FileHelper
    {
        public static void PrepareDirectory(string filePath)
        {
            var dirName = new FileInfo(filePath)?.Directory?.FullName;

            if (!string.IsNullOrEmpty(dirName) && !Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
        }
    }
}
