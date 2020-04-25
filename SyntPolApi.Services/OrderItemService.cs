using SyntPolApi.Core;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<OrderItem> CreateOrderItem(OrderItem orderItem)
        {
            await unitOfWork.OrderItems.AddAsync(orderItem);
            await unitOfWork.CommitAsync();

            return orderItem;
        }
    }
}
