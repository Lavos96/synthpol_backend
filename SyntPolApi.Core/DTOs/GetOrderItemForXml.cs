using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.DTOs
{
    public class GetOrderItemForXml
    {
        public int OrderItemId { get; set; }
        public int Amount { get; set; }
        public decimal BruttoPrice { get; set; }
        public decimal NettoPrice { get; set; }

        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
