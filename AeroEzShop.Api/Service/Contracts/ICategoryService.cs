using AeroEzShop.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Service.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryTree> GetCategoriesTree();
    }
}
