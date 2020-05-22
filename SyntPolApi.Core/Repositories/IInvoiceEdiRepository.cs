using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Repositories
{
    public interface IInvoiceEdiRepository : IRepository<InvoiceEdi>
    {
        ValueTask<string> GetByInvoiceId(int id);
        ValueTask<string> GetXmlByInvoiceId(int id);
        Task Remove(int id);
    }
}
