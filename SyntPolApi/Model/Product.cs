﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int VAT { get; set; }
        public decimal NettoPrice { get; set; }
        public string Description { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
