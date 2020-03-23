using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        Task UpdateOrder(Order orderToBeUpdated, Order order);
        Task DeleteOrder(int id);

        //"standard" GetAll (ShallDisplay == true)
        Task<IEnumerable<Order>> GetAsync();
        ValueTask<Order> GetByIdAsync(int id);

        //full GetAll (including those with flag ShallDisplay set to false)
        Task<IEnumerable<Order>> GetAllAsync();
        ValueTask<Order> GetFromAllByIdAsync(int id);

        Task<IEnumerable<Order>> GetOrdersWithProductsAsync();
        Task<IEnumerable<Order>> GetAllOrdersWithProductsAsync();
        ValueTask<Order> GetWithProductsAsync(int id);
        ValueTask<Order> GetFromAllOrdersWithProductsAsync(int id);
    }
}
