using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public decimal Amount { get; set; }
    }
}