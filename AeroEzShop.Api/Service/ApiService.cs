using AeroEzShop.Api.Config;
using AeroEzShop.Api.Models;
using AeroEzShop.Api.Service.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Service
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
