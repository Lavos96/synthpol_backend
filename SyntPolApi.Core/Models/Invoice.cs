using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string NIP { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
