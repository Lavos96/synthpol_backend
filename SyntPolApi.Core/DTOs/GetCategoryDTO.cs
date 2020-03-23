using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.DTOs
{
    public class GetCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool ShallDisplay { get; set; }
    }
}
