using Microsoft.EntityFrameworkCore;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Repositories;
using SyntPolApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly SyntPolApiDbContext syntPolApiDbContext;

        public ProductRepository(SyntPolApiDbContext context) : base(context)
        {
            syntPolApiDbContext = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryAndProviderAsync(int catId, int provId)
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.CategoryId == catId)
                .Include(p => p.Category)
                .Where(p => p.ProviderId == provId)
                .Include(p =>p.Provider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(int catId)
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.CategoryId == catId)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByProviderAsync(int provId)
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.ProviderId == provId)
                .Include(p => p.Provider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.ShallDisplay)
                .ToListAsync();
        }

        public async ValueTask<Product> GetByIdAsync(int id)
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.ShallDisplay)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAndProviderAsync(int catId, int provId)
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.ShallDisplay)
                .Where(p => p.CategoryId == catId)
                .Include(p => p.Category)
                .Where(p => p.ProviderId == provId)
                .Include(p => p.Provider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int catId)
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.ShallDisplay)
                .Where(p => p.CategoryId == catId)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByProviderAsync(int provId)
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.ShallDisplay)
                .Where(p => p.ProviderId == provId)
                .Include(p => p.Provider)
                .ToListAsync();
        }

        public async void Remove(int id)
        {
            var product = await syntPolApiDbContext.Products.FirstOrDefaultAsync(pr => pr.ProductId == id);
            product.ShallDisplay = false;
        }
    }
}
