using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InstagramSpider.Common.Utils
{
    public class CustomHttpClient
    {
        private readonly HttpClient _http = new HttpClient();

        public void SetHeader(string name, string value)
        {
            _http.DefaultRequestHeaders.Add(name, value);
        }

        public async Task<TResponse> GetJson<TResponse, TRequest>(string url, TRequest param)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var responseContent = await (await _http.SendAsync(request)).Content.ReadAsStringAsync();
            var respModel = JsonConvert.DeserializeObject<TResponse>(responseContent);

            return respModel;
        }

        public async Task<string> Get(string url)
        {
            var response = await _http.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
