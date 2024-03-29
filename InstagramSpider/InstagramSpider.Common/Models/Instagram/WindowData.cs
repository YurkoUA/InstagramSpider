﻿using System.Collections.Generic;
using Newtonsoft.Json;
using InstagramSpider.Common.Utils;

namespace InstagramSpider.Common.Models.Instagram
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class WindowData
    {
        [JsonProperty("config.csrf_token")]
        public string CsrfToken { get; set; }

        [JsonProperty("entry_data.ProfilePage")]
        public IEnumerable<GraphQLUser> Users { get; set; }
    }
}
