using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal BruttoPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
