using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data;
using TestTask.Data.Models;

namespace TestTast.Application
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task DeleteOrder(Guid Id)
        {
            var order = await _repository.Query().FirstOrDefaultAsync(r => r.Id == Id);

            if (order == null)
                throw new Exception("Such order is not exist!!!");

            await _repository.DeleteAsync(order);
        }

        public async Task<List<Order>> GetOrder()
        {
            var order = await _repository.Query().ToListAsync();

            if (order.Count == 0)
            {
                throw new Exception("Orders are not exist!!!");
            }

            return order;
        }
    }
}
