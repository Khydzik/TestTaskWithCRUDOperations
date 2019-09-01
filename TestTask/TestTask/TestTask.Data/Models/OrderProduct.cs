using System;

namespace TestTask.Data.Models
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public Order Orders { get; set; }
        public Product Products { get; set; }
    }
}
