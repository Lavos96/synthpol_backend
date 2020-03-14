using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyntPolApi.DAL;
using SyntPolApi.Model;

namespace SyntPolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly SyntPolDbContext _context;

        public ProvidersController(SyntPolDbContext context)
        {
            _context = context;
        }

        // GET: api/Providers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provider>>> GetProviders()
        {
            return await _context.Providers
                .Where(s => s.ShallDisplay)
                .ToListAsync();
        }

        // GET: api/Providers
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Provider>>> GetAllProviders()
        {
            return await _context.Providers
                .ToListAsync();
        }

        // GET: api/Providers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provider>> GetProvider(int id)
        {
            var provider = await _context.Providers.FindAsync(id);

            if (provider == null || !provider.ShallDisplay)
            {
                return NotFound();
            }

            return provider;
        }

        // GET: api/Providers/5
        [HttpGet("all/{id}")]
        public async Task<ActionResult<Provider>> GetDeletedProvider(int id)
        {
            var provider = await _context.Providers.FindAsync(id);

            if (provider == null)
            {
                return NotFound();
            }

            return provider;
        }

        // PUT: api/Providers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvider(int id, Provider provider)
        {
            if (id != provider.ProviderId)
            {
                return BadRequest();
            }

            _context.Entry(provider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Providers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Provider>> PostProvider(Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvider", new { id = provider.ProviderId }, provider);
        }

        // DELETE: api/Providers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Provider>> DeleteProvider(int id)
        {
            var provider = await _context.Providers.FindAsync(id);
            if (provider == null)
            {
                return NotFound();
            }

            provider.ShallDisplay = false;

            await TryUpdateModelAsync(provider);
            await _context.SaveChangesAsync();

            return provider;
        }

        private bool ProviderExists(int id)
        {
            return _context.Providers.Any(e => e.ProviderId == id);
        }
    }
}
