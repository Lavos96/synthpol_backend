using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.DTOs
{
    public class GetOrderItemDTO
    {
        public int OrderItemId { get; set; }
        public int Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal BruttoPrice { get; set; }

        public int ProductId { get; set; }
        public GetProductForOrderDTO Product { get; set; }
    }
}
