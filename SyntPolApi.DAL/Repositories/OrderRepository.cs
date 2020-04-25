using Microsoft.EntityFrameworkCore;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly SyntPolApiDbContext syntPolApiDbContext;

        public OrderRepository(SyntPolApiDbContext context): base(context)
        {
            syntPolApiDbContext = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithProducts()
        {
            return await syntPolApiDbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .ToListAsync();
        }

        public async ValueTask<Order> GetFromAllOrdersWithProductsAsync(int id)
        {
            return await syntPolApiDbContext.Orders
                .Where(o => o.ShallDisplay)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersWithProducts()
        {
            return await syntPolApiDbContext.Orders
                .Where(o => o.ShallDisplay)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .ToListAsync();
        }

        public async ValueTask<Order> GetWithProductsAsync(int id)
        {
            return await syntPolApiDbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithProductsByUsername(string username)
        {
            return await syntPolApiDbContext.Orders
                .Where(o => o.Username == username)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await syntPolApiDbContext.Orders
                .Where(o => o.ShallDisplay)
                .ToListAsync();
        }

        public async ValueTask<Order> GetByIdAsync(int id)
        {
            return await syntPolApiDbContext.Orders
                .Where(o => o.ShallDisplay)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task Remove(int id)
        {
            var order = await syntPolApiDbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            order.ShallDisplay = false;
            await syntPolApiDbContext.SaveChangesAsync();
        }

        
    }
}
