using AeroEzShop.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Service.Contracts
{
    public interface IDollarService
    {
        Task<DollarResponse> GetDollarInfo();
    }
}
