using InstagramSpider.Common.Utils;
using Newtonsoft.Json;

namespace InstagramSpider.Common.Models.Instagram
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class GraphQLUser
    {
        [JsonProperty("graphql.user")]
        public UserProfile User { get; set; }
    }
}
