using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SyntPolApi.Core.DTOs;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using SyntPolApi.DAL;

namespace SyntPolApi.Controllers
{
    //TODO: invoicesController put
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        private readonly IMapper mapper;

        public InvoicesController(IInvoiceService invoiceService, IMapper mapper)
        {
            this.invoiceService = invoiceService;
            this.mapper = mapper;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> getAllInvoices()
        {
            var invoices = await invoiceService.GetAllWithProductsAsync();
            if (invoices == null)
            {
                return NotFound();
            }

            var mappedInvoices = mapper.Map<IEnumerable<Invoice>, IEnumerable<GetInvoiceDTO>>(invoices);
            return Ok(mappedInvoices);
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceWithDetailsFromAll(int id)
        {
            var invoice = await invoiceService.GetWithProductsAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            var mappedInvoice = mapper.Map<Invoice, GetInvoiceDTO>(invoice);
            return Ok(mappedInvoice);
        }

        // GET: api/Invoices/user/{username}
        [HttpGet("user/{username}")]
        public async Task<ActionResult<Invoice>> GetInvoiceWithDetailsFromAll(string username)
        {
            var invoices = await invoiceService.GetWithProductsByUsernameAsync(username);
            if (invoices == null)
            {
                return NotFound();
            }

            var mappedInvoices = mapper.Map<IEnumerable<Invoice>, IEnumerable<GetInvoiceDTO>>(invoices);
            return Ok(mappedInvoices);
        }
    }
}