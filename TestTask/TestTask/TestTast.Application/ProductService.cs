using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data;
using TestTask.Data.Models;

namespace TestTast.Application
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product> CreateProduct(string name, decimal price)
        {
            var product = await _repository.GetAsync(u => u.Name == name);

            if (product != null)
            {
                throw new Exception("Such product exist !!!");
            }

            var newproduct = new Product
            {
                Name = name,
                Price = price
            };

            return await _repository.InsertAsync(newproduct);
        }

        public async Task DeleteProduct(Guid Id)
        {
            var order = await _repository.Query().FirstOrDefaultAsync(r => r.Id == Id);

            if (order == null)
                throw new Exception("Such order is not exist!!!");

            await _repository.DeleteAsync(order);
        }

        public async Task<List<Product>> GetProduct()
        {
            var product = await _repository.Query().ToListAsync();

            if (product == null)
                throw new Exception("Products are not exist!!!");

            return product;
        }
    }
}
