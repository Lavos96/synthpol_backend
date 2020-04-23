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
        private OrderRepository orderRepository;
        private OrderItemRepository orderItemRepository;
        private InvoiceRepository invoiceRepository;

        public UnitOfWork(SyntPolApiDbContext context)
        {
            this.context = context;
        }

        public IProductRepository Products => productRepository = productRepository ?? new ProductRepository(context);

        public IProviderRepository Providers => providerRepository = providerRepository ?? new ProviderRepository(context);

        public ICategoryRepository Categories => categoryRepository = categoryRepository ?? new CategoryRepository(context);

        public IOrderRepository Orders => orderRepository = orderRepository ?? new OrderRepository(context);
        public IOrderItemRepository OrderItems => orderItemRepository = orderItemRepository ?? new OrderItemRepository(context);
        public IInvoiceRepository Invoices => invoiceRepository = invoiceRepository ?? new InvoiceRepository(context);

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
