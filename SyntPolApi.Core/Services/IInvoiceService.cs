using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Services
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateInvoice(Invoice invoice);
        Task UpdateInvoice(Invoice invoiceToBeUpdated, Invoice invoice);
        Task DeleteInvoice(int id);

        Task<IEnumerable<Invoice>> GetAllAsync();
        ValueTask<Invoice> GetFromAllByIdAsync(int id);
        ValueTask<Invoice> GetWithProductsAsync(int id);

        Task<IEnumerable<Invoice>> GetWithProductsByUsernameAsync(string username);
    }
}
