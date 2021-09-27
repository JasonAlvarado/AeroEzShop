using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("category_tree")]
        public async Task<IActionResult> Get()
        {
            var categoryTree = await categoryService.GetCategoriesTree();
            return Ok(categoryTree);
        }
    }
}
