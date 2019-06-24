using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InstagramSpider.Common.Models.Instagram;
using InstagramSpider.Common.Utils;
using Newtonsoft.Json;

namespace InstagramSpider.Common
{
    public class InstagramClient
    {
        private readonly CustomHttpClient _httpClient = new CustomHttpClient();

        public async Task<WindowData> GetProfile(string userName)
        {
            var html = await _httpClient.Get($"https://instagram.com/{userName}");
            var pattern = @"window._sharedData = {.*};</script>";
            var match = Regex.Match(html, pattern);

            if (!match.Success)
            {
                throw new Exception("Profile not found.");
            }

            html = match.Value;
            html = html.Replace("window._sharedData = ", string.Empty);
            html = html.Replace(";</script>", string.Empty);

            var profile = JsonConvert.DeserializeObject<WindowData>(html);

            // TODO: Set headers.

            return profile;
        }
    }
}
