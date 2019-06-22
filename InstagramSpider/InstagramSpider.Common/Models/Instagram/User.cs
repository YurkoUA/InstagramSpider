using Newtonsoft.Json;

namespace InstagramSpider.Common.Models.Instagram
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }
    }
}
