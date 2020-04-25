using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;

namespace SyntPolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesEdiController : ControllerBase
    {
        private readonly IInvoiceEdiService invoiceEdiService;

        public InvoicesEdiController(IInvoiceEdiService invoiceEdiService)
        {
            this.invoiceEdiService = invoiceEdiService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceEdi>> GetInvoiceEdiByInvoiceId(int id)
        {
            var invoiceEdi = await invoiceEdiService.GetByInvoiceId(id);
            if (invoiceEdi == null)
            {
                return NotFound();
            }

            return Ok(invoiceEdi);
        }
    }
}