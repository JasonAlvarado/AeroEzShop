using Models.Config;
using Models.Response;
using Service.Contracts;
using System.Threading.Tasks;

namespace Service
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
