using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.DTOs
{
    public class GetInvoiceDTO
    {
        public int InvoiceId { get; set; }
        public int? InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string NIP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
}
