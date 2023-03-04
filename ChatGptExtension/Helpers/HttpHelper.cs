using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatGptExtension.Helpers
{
    internal class HttpHelper
    {
        public async static Task<string> PostAsync<T>(string url, string apiKey, T body)
        {
            using HttpClient client = new HttpClient();

            string deserialized = JsonConvert.SerializeObject(body);
            
            StringContent content = new StringContent(deserialized);
            content.Headers.Add("Content-Type", "application/json");
            content.Headers.Add("Authorization", "Bearer " + apiKey);

            HttpResponseMessage response = await client.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                return string.Empty;
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
