using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.DTOs
{
    public class GetOrderDTO
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime SellDate { get; set; }

        public decimal OrderValue { get; set; }
        public OrderState OrderState { get; set; }
        public bool ShallDisplay { get; set; }
        public ICollection<GetOrderItemDTO> OrderItems { get; set; }
    }
}
