using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        ValueTask<Invoice> GetWithProductsAsync(int id);
        Task<IEnumerable<Invoice>> GetWithProductsByUsernameAsync(string username);
        Task<IEnumerable<Invoice>> GetAllWithProductsAsync();
        Task Remove(int id);
    }
}
