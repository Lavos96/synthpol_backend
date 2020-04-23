using Microsoft.EntityFrameworkCore;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Repositories;
using System;
using System.Collections.Generic;
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

        public async Task Remove(int id)
        {
            var invoice = await syntPolApiDbContext.Invoices.FirstOrDefaultAsync(i => i.InvoiceId == id);
            syntPolApiDbContext.Invoices.Remove(invoice);
            await syntPolApiDbContext.SaveChangesAsync();
        }
    }
}
