using Microsoft.EntityFrameworkCore;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.DAL.Repositories
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        private readonly SyntPolApiDbContext syntPolApiDbContext;

        public ProviderRepository(SyntPolApiDbContext context): base(context)
        {
            syntPolApiDbContext = context;
        }

        public async Task<IEnumerable<Provider>> GetAsync()
        {
            return await syntPolApiDbContext.Providers.Where(pr => pr.ShallDisplay).ToListAsync();
        }

        public async ValueTask<Provider> GetByIdAsync(int id)
        {
            return await syntPolApiDbContext.Providers.Where(pr => pr.ShallDisplay).FirstOrDefaultAsync(pr => pr.ProviderId == id);
        }

        public async Task Remove(int id)
        {
            var provider = await syntPolApiDbContext.Providers.FirstOrDefaultAsync(pr => pr.ProviderId == id);
            provider.ShallDisplay = false;
            await syntPolApiDbContext.SaveChangesAsync();
        }
    }
}
