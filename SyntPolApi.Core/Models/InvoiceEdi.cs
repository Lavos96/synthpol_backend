using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.Models
{
    public class InvoiceEdi
    {
        public int InvoiceEdiId { get; set; }
        public string EdiString { get; set; }
        public string Username { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
