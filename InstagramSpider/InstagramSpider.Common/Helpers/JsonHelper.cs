using Newtonsoft.Json;

namespace InstagramSpider.Common.Helpers
{
    public static class JsonHelper
    {
        public static string Serialize(object data)
        {
            var str = JsonConvert.SerializeObject(data);
            return str;
        }

        public static T Deserialize<T>(string json)
        {
            var model = JsonConvert.DeserializeObject<T>(json);
            return model;
        }
    }
}
