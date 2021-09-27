using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IApiService
    {
        Task<T> Get<T>(string path);
    }
}
