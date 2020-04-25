using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.DTOs
{
    public class GetProductForOrderDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int VAT { get; set; }
        public decimal NettoPrice { get; set; }
        public string Description { get; set; }
        public string PhotoString { get; set; }
        public bool ShallDisplay { get; set; }

    }
}
