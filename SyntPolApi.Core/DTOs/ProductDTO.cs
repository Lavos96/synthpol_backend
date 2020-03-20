using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int VAT { get; set; }
        public decimal NettoPrice { get; set; }
        public string Description { get; set; }
        public string PhotoString { get; set; }
        public bool ShallDisplay { get; set; }

        public int ProviderId { get; set; }
        public ProviderDTO Provider { get; set; }

        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
