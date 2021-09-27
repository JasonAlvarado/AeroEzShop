using Models;
using Models.Config;
using Models.Response;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Service
{
    public class ProductService : IProductService
    {
        private readonly IApiService apiService;
        private readonly IDollarService dollarService;
        private const int DaysInAMonth = 30;

        public ProductService(IApiService apiService, IDollarService dollarService)
        {
            this.apiService = apiService;
            this.dollarService = dollarService;
        }

        public async Task<List<Product>> GetProducts(int page = 1)
        {
            ProductResponse productResponse = await apiService.Get<ProductResponse>($"{ApiPaths.Products}?page={page}");

            List<Product> products = productResponse.Products;

            if (products == null)
                return null;

            List<Product> activeProducts = products.Where(prod => (DateTime.Now - prod.UpdatedAt).TotalDays <= DaysInAMonth).ToList();

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
