using SyntPolApi.Core;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {
            await unitOfWork.Invoices.AddAsync(invoice);
            await unitOfWork.CommitAsync();
            return invoice;
        }

        public async Task DeleteInvoice(int id)
        {
            await unitOfWork.Invoices.Remove(id);
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await unitOfWork.Invoices.GetAllAsync();
        }

        public async ValueTask<Invoice> GetFromAllByIdAsync(int id)
        {
            return await unitOfWork.Invoices.GetFromAllByIdAsync(id);
        }

        public async Task UpdateInvoice(Invoice invoiceToBeUpdated, Invoice invoice)
        {
            invoiceToBeUpdated.City = invoice.City;
            invoiceToBeUpdated.Name = invoice.Name;
            invoiceToBeUpdated.NIP = invoice.NIP;
            invoiceToBeUpdated.Street = invoice.Street;
            invoiceToBeUpdated.ZipCode = invoice.ZipCode;
            invoiceToBeUpdated.Username = invoice.Username;

            await unitOfWork.CommitAsync();
        }

        public async ValueTask<Invoice> GetWithProductsAsync(int id)
        {
            return await unitOfWork.Invoices.GetWithProductsAsync(id);
        }

        public async Task<IEnumerable<Invoice>> GetWithProductsByUsernameAsync(string username)
        {
            return await unitOfWork.Invoices.GetWithProductsByUsernameAsync(username);
        }

        public async Task<IEnumerable<Invoice>> GetAllWithProductsAsync()
        {
            return await unitOfWork.Invoices.GetAllWithProductsAsync();
        }
    }
}
