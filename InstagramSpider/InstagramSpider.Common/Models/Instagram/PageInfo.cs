using Newtonsoft.Json;

namespace InstagramSpider.Common.Models.Instagram
{
    public class PageInfo
    {
        [JsonProperty("has_next_page")]
        public bool HasNextPage { get; set; }

        [JsonProperty("end_cursor")]
        public string EndCursor { get; set; }
    }
}
