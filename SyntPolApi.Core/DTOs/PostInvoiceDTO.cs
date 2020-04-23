using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.DTOs
{
    public class PostInvoiceDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string NIP { get; set; }
        public string Country { get; set; }
    }
}
