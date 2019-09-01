using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Models;

namespace TestTast.Application
{
    public interface IProductService
    {
        Task<Product> CreateProduct(string name, decimal price);
        Task<List<Product>> GetProduct();
        Task DeleteProduct(Guid Id);
    }
}
