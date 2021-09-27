using AeroEzShop.Api.Config;
using AeroEzShop.Api.Models;
using AeroEzShop.Api.Models.Response;
using AeroEzShop.Api.Service.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IApiService apiService;

        public CategoryService(IApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<CategoryTree> GetCategoriesTree()
        {
            CategoryResponse categoriesApiResponse = await apiService.Get<CategoryResponse>(ApiPaths.Categories);
            List<Category> categories = categoriesApiResponse.Categories;

            if (categories == null)
                return null;

            List<CategoryTreeItem> categoryTreeItems = new List<CategoryTreeItem>();

            // usar recursion

            CategoryTree categoryTree = new CategoryTree() { CategoyTreeItems = categoryTreeItems };
            return categoryTree;
        }
    }
}
