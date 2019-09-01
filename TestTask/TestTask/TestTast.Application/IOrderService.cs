using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Models;

namespace TestTast.Application
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrder();
        Task DeleteOrder(Guid Id);
    }
}
