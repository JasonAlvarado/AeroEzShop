using AeroEzShop.Api.Config;
using AeroEzShop.Api.Models;
using AeroEzShop.Api.Models.Response;
using AeroEzShop.Api.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Service
{
    public class ProductService : IProductService
    {
        private readonly IApiService apiService;
        private readonly IDollarService dollarService;

        public ProductService(IApiService apiService, IDollarService dollarService)
        {
            this.apiService = apiService;
            this.dollarService = dollarService;
        }

        public async Task<List<Product>> GetProducts()
        {
            ProductResponse productResponse = await apiService.Get<ProductResponse>(ApiPaths.Products);

            List<Product> products = productResponse.Products;
            List<Product> activeProducts = products.Where(prod => (DateTime.Now - prod.UpdatedAt).TotalDays <= 30).ToList();

            DollarResponse dollarInfo = await dollarService.GetDollarInfo();

            if (dollarInfo == null || dollarInfo.Rate == 0)
                return activeProducts;

            foreach (var item in activeProducts)
            {
                item.DollarPrice = Math.Round((item.Price / dollarInfo.Rate), 2);
            }

            return activeProducts;
        }
    }
}
