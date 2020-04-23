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
            var invoices = await invoiceService.GetAllAsync();
            if (invoices == null)
            {
                return NotFound();
            }

            var mappedInvoices = mapper.Map<IEnumerable<Invoice>, IEnumerable<GetInvoiceDTO>>(invoices);
            return Ok(mappedInvoices);
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceFromAll(int id)
        {
            var invoice = await invoiceService.GetFromAllByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            var mappedInvoice = mapper.Map<Invoice, GetInvoiceDTO>(invoice);
            return Ok(mappedInvoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var invoiceToBeDeleted = await invoiceService.GetFromAllByIdAsync(id);

            if (invoiceToBeDeleted == null)
            {
                return NotFound();
            }
            await invoiceService.DeleteInvoice(id);

            return NoContent();
        }
    }
}