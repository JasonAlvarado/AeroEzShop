using Models;
using Models.Config;
using Models.Response;
using Service.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
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

            foreach (var item in categories)
            {
                if (item.ParentId == null)
                {
                    categoryTreeItems.Add(new CategoryTreeItem() { Id = item.Id, Name = item.Name, ParentId = null, Subcategories = new List<Category>() });
                }
                else
                {
                    categoryTreeItems.FirstOrDefault(cat => cat.Id == item.ParentId)?.Subcategories.Add(item);
                }
            }

            CategoryTree categoryTree = new CategoryTree() { CategoyTreeItems = categoryTreeItems };
            return categoryTree;
        }
    }
}
