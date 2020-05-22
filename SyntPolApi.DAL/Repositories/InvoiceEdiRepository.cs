using Microsoft.EntityFrameworkCore;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.DAL.Repositories
{
    public class InvoiceEdiRepository : Repository<InvoiceEdi>, IInvoiceEdiRepository
    {
        private readonly SyntPolApiDbContext syntPolApiDbContext;
        public InvoiceEdiRepository(SyntPolApiDbContext context) : base(context)
        {
            syntPolApiDbContext = context;
        }

        public async ValueTask<string> GetByInvoiceId(int id)
        {
            var invoiceEdi = await syntPolApiDbContext.InvoicesEdi.FirstOrDefaultAsync(ie => ie.InvoiceId == id);
            return invoiceEdi.EdiString;
        }

        public async ValueTask<string> GetXmlByInvoiceId(int id)
        {
            var invoiceEdi = await syntPolApiDbContext.InvoicesEdi.FirstOrDefaultAsync(ie => ie.InvoiceId == id);
            return invoiceEdi.XmlString;
        }

        public async Task Remove(int id)
        {
            var invoiceEdi = await syntPolApiDbContext.InvoicesEdi.FirstOrDefaultAsync(ie => ie.InvoiceEdiId == id);
            syntPolApiDbContext.InvoicesEdi.Remove(invoiceEdi);
            await syntPolApiDbContext.SaveChangesAsync();
        }
    }
}
