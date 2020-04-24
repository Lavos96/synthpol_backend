using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Amount { get; set; }
        public decimal BruttoPrice { get; set; }
        public decimal NettoPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
