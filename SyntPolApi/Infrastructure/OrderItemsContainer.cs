using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.Infrastructure
{
    public class OrderItemsContainer
    {
        public OrderItem[] OrderItems { get; set; }

        public OrderItemsContainer()
        {

        }
    }
}
