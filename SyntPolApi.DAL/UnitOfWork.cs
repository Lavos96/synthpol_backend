using SyntPolApi.Core;
using SyntPolApi.Core.Repositories;
using SyntPolApi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SyntPolApiDbContext context;
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private ProviderRepository providerRepository;

        public UnitOfWork(SyntPolApiDbContext context)
        {
            this.context = context;
        }

        public IProductRepository Products => productRepository = productRepository ?? new ProductRepository(context);

        public IProviderRepository Providers => providerRepository = providerRepository ?? new ProviderRepository(context);

        public ICategoryRepository Categories => categoryRepository = categoryRepository ?? new CategoryRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
