using Newtonsoft.Json;
using Service.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        //public async Task<HttpResponseMessage> Get<T>(string path)
        public async Task<T> Get<T>(string path)
        {
            HttpClient httpClient = httpClientFactory.CreateClient("EzShopApi");
            var request = new HttpRequestMessage(HttpMethod.Get, path);

            HttpResponseMessage data = await httpClient.SendAsync(request);

            if (data.IsSuccessStatusCode)
            {
                string jsonData = await data.Content.ReadAsStringAsync();
                T info = JsonConvert.DeserializeObject<T>(jsonData);
                return info;
            }

            return Activator.CreateInstance<T>();
        }
    }
}
