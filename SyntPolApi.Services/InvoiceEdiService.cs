using SyntPolApi.Core;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Services
{
    public class InvoiceEdiService : IInvoiceEdiService
    {
        private readonly IUnitOfWork unitOfWork;

        public InvoiceEdiService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<InvoiceEdi> CreateInvoiceEdi(InvoiceEdi invoiceEdi)
        {
            await unitOfWork.InvoicesEdi.AddAsync(invoiceEdi);
            await unitOfWork.CommitAsync();
            return invoiceEdi;
        }

        public async Task DeleteInvoiceEdi(int id)
        {
            await unitOfWork.InvoicesEdi.Remove(id);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<InvoiceEdi>> GetAllAsync()
        {
            return await unitOfWork.InvoicesEdi.GetAllAsync();
        }

        public async ValueTask<InvoiceEdi> GetFromAllByIdAsync(int id)
        {
            return await unitOfWork.InvoicesEdi.GetFromAllByIdAsync(id);
        }

        public async ValueTask<string> GetByInvoiceId(int id)
        {
            return await unitOfWork.InvoicesEdi.GetByInvoiceId(id);
        }

        public async Task UpdateInvoiceEdi(InvoiceEdi invoiceEdiToBeUpdated, InvoiceEdi invoiceEdi)
        {
            invoiceEdiToBeUpdated.EdiString = invoiceEdi.EdiString;
            invoiceEdiToBeUpdated.Username = invoiceEdi.Username;

            await unitOfWork.CommitAsync();
        }
    }
}
