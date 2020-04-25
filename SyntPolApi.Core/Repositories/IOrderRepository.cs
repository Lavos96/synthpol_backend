using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        //"standard" GetAll (ShallDisplay == true)
        //full GetAll (including those with flag ShallDisplay set to false) is located in base repository (IRepository.cs)
        Task<IEnumerable<Order>> GetAsync();
        ValueTask<Order> GetByIdAsync(int id);

        Task<IEnumerable<Order>> GetOrdersWithProducts();
        Task<IEnumerable<Order>> GetAllOrdersWithProducts();

        Task<IEnumerable<Order>> GetAllOrdersWithProductsByUsername(string username);

        ValueTask<Order> GetWithProductsAsync(int id);
        ValueTask<Order> GetFromAllOrdersWithProductsAsync(int id);

        //remove does not actually remove (updates ShallDisplay to false instead)
        Task Remove(int id);
    }
}
