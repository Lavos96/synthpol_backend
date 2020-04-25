using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Services
{
    public interface IInvoiceEdiService
    {
        Task<InvoiceEdi> CreateInvoiceEdi(InvoiceEdi invoiceEdi);
        Task UpdateInvoiceEdi(InvoiceEdi invoiceEdiToBeUpdated, InvoiceEdi invoiceEdi);
        Task DeleteInvoiceEdi(int id);
        ValueTask<string> GetByInvoiceId(int id);


        Task<IEnumerable<InvoiceEdi>> GetAllAsync();
        ValueTask<InvoiceEdi> GetFromAllByIdAsync(int id);
    }
}
