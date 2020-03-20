using Microsoft.EntityFrameworkCore;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly SyntPolApiDbContext syntPolApiDbContext;
        public CategoryRepository(SyntPolApiDbContext context) : base(context) {
            syntPolApiDbContext = context;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await syntPolApiDbContext.Categories.Where(p => p.ShallDisplay).ToListAsync();
        }

        public async ValueTask<Category> GetByIdAsync(int id)
        {
            return await syntPolApiDbContext.Categories.Where(p => p.ShallDisplay).FirstOrDefaultAsync(p => p.CategoryId == id);
        }

        public async void Remove(int id)
        {
            var category = await syntPolApiDbContext.Categories.FirstOrDefaultAsync(cat => cat.CategoryId == id);
            category.ShallDisplay = false;
        }
    }
}
