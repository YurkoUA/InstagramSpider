using InstagramSpider.Common.Utils;
using Newtonsoft.Json;

namespace InstagramSpider.Common.Models.Instagram
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class UserProfile : User
    {
        [JsonProperty("profile_pic_url_hd")]
        public string ProfilePictureUrl { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("highlight_reel_count")]
        public int StoriesCount { get; set; }

        [JsonProperty("edge_followed_by.count")]
        public int FollowersCount { get; set; }

        [JsonProperty("edge_follow.count")]
        public int FollowsCount { get; set; }

        [JsonProperty("edge_owner_to_timeline_media")]
        public Page<Image> Media { get; set; }
    }
}
