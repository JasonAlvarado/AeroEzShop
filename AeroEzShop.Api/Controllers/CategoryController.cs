using AeroEzShop.Api.Models;
using AeroEzShop.Api.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("category_tree")]
        public async Task<CategoryTree> Get()
        {
            CategoryTree categoryTree = await categoryService.GetCategoriesTree();
            return categoryTree;
        }
    }
}
