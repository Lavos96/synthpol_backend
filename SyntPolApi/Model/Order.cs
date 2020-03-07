using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime SellDate { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
