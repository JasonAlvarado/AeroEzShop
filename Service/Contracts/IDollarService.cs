using Models.Response;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDollarService
    {
        Task<DollarResponse> GetDollarInfo();
    }
}
