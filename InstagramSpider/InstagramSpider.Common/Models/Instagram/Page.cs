using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstagramSpider.Common.Models.Instagram
{
    public class Page<T>
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("edges")]
        public IEnumerable<NodeModel<T>> Media { get; set; }
    }
}