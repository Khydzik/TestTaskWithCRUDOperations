using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data.Models;
using TestTast.Application;

namespace TestTask.Web.Controllers
{
    [ApiController]
    [Route("site/api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<List<Order>> GetOrder()
        {
            return await _orderService.GetOrder();            
        }
    }
}
