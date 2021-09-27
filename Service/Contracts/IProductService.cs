using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(int page = 1);
    }
}
