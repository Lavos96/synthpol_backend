using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Core.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task Remove(int id);
    }
}
