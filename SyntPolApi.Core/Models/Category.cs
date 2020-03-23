using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool ShallDisplay { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
