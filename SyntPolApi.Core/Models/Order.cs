using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime SellDate { get; set; }

        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public decimal OrderValue { get; set; }
        public OrderState OrderState { get; set; }
        public bool ShallDisplay { get; set; }
        public string Username { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public enum OrderState
    {
        New,
        Completed
    }
}