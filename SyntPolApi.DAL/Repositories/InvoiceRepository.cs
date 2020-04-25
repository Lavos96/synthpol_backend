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
    public class InvoiceRepository: Repository<Invoice>, IInvoiceRepository
    {
        private readonly SyntPolApiDbContext syntPolApiDbContext;

        public InvoiceRepository(SyntPolApiDbContext context) : base(context)
        {
            syntPolApiDbContext = context;
        }

        public async ValueTask<Invoice> GetWithProductsAsync(int id)
        {
            var invoice = await syntPolApiDbContext.Invoices
                .Include(i => i.Order)
                .ThenInclude(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(i => i.InvoiceId == id);
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetWithProductsByUsernameAsync(string username)
        {
            var invoices = await syntPolApiDbContext.Invoices
                .Where(i => i.Username == username)
                .Include(i => i.Order)
                .ThenInclude(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
            return invoices;
        }

        public async Task Remove(int id)
        {
            var invoice = await syntPolApiDbContext.Invoices.FirstOrDefaultAsync(i => i.InvoiceId == id);
            syntPolApiDbContext.Invoices.Remove(invoice);
            await syntPolApiDbContext.SaveChangesAsync();
        }


    }
}
