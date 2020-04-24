using System;
using System.Collections.Generic;
using System.Text;

namespace SyntPolApi.Core.DTOs
{
    public class PostOrderDTO
    {
        //public PostInvoiceDTO Invoice { get; set; }
        public List<PostOrder> PostOrders { get; set; }
    }

    public class PostOrder
    {
        public int ProductId { get; set; }
        public int QuantityOfProducts { get; set; }

    }
}
