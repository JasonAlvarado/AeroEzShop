using AeroEzShop.Api.Config;
using AeroEzShop.Api.Models.Response;
using AeroEzShop.Api.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Service
{
    public class DollarService : IDollarService
    {
        private readonly IApiService apiService;

        public DollarService(IApiService apiService)
        {
            this.apiService = apiService;
        }
        public async Task<DollarResponse> GetDollarInfo()
        {
            DollarResponse data = await apiService.Get<DollarResponse>(ApiPaths.Dollar);
            return data;
        }
    }
}
