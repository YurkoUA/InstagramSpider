using Newtonsoft.Json;
using InstagramSpider.Common.Utils;


namespace InstagramSpider.Common.Models.Instagram
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class Image
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        //[JsonProperty("edge_media_to_caption.edges.0.node.text")]
        //public string Text { get; set; }

        [JsonProperty("display_url")]
        public string Url {get; set; }

        [JsonProperty("accessibility_caption")]
        public string AccessibilityCaption { get; set; }

        [JsonProperty("edge_liked_by.count")]
        public int LikesCount { get; set; }

        [JsonProperty("edge_media_to_comment.count")]
        public int CommentsCount { get; set; }

        [JsonProperty("taken_at_timestamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("is_video")]
        public bool IsVideo { get; set; }

        [JsonProperty("location.name")]
        public string LocationName { get; set; }
    }
}
