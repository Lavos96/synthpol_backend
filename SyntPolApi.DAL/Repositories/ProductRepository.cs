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

        public async Task<IEnumerable<Product>> GetAllProductsWithCategoryAndProviderAsync()
        {
            return await syntPolApiDbContext.Products
                .Include(p => p.Category)
                .Include(p =>p.Provider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithCategoryAsync()
        {
            return await syntPolApiDbContext.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithProviderAsync()
        {
            return await syntPolApiDbContext.Products
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

        public async Task<IEnumerable<Product>> GetProductsWithCategoryAndProviderAsync()
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.ShallDisplay)
                .Include(p => p.Category)
                .Include(p => p.Provider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithCategoryAsync()
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.ShallDisplay)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithProviderAsync()
        {
            return await syntPolApiDbContext.Products
                .Where(p => p.ShallDisplay)
                .Include(p => p.Provider)
                .ToListAsync();
        }
    }
}
