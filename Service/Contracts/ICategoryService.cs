using Models;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryTree> GetCategoriesTree();
    }
}
