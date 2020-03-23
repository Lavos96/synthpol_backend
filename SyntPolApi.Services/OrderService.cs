using SyntPolApi.Core;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await unitOfWork.Orders.AddAsync(order);
            await unitOfWork.CommitAsync();
            return order;
        }

        public async Task DeleteOrder(int id)
        {
            await unitOfWork.Orders.Remove(id);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await unitOfWork.Orders.GetAllAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithProductsAsync()
        {
            return await unitOfWork.Orders.GetAllOrdersWithProducts();
        }

        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await unitOfWork.Orders.GetAsync();
        }

        public async ValueTask<Order> GetByIdAsync(int id)
        {
            return await unitOfWork.Orders.GetByIdAsync(id);
        }

        public async ValueTask<Order> GetFromAllByIdAsync(int id)
        {
            return await unitOfWork.Orders.GetFromAllByIdAsync(id);
        }

        public async ValueTask<Order> GetFromAllOrdersWithProductsAsync(int id)
        {
            return await unitOfWork.Orders.GetFromAllOrdersWithProductsAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersWithProductsAsync()
        {
            return await unitOfWork.Orders.GetOrdersWithProducts();
        }

        public async ValueTask<Order> GetWithProductsAsync(int id)
        {
            return await unitOfWork.Orders.GetWithProductsAsync(id);
        }

        public async Task UpdateOrder(Order orderToBeUpdated, Order order)
        {
            orderToBeUpdated.OrderState = order.OrderState;
            orderToBeUpdated.OrderValue = order.OrderValue;
            orderToBeUpdated.ShallDisplay = order.ShallDisplay;

            await unitOfWork.CommitAsync();
        }
    }
}
