using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Services
{
    public interface IOrderItemService
    {
        //this table most likely will not be accessed, so there aren't any get methods
        //however it may change in the future
        Task<OrderItem> CreateOrderItem(OrderItem orderItem);
    }
}
