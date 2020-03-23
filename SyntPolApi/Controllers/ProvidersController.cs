using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyntPolApi.Core.DTOs;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using SyntPolApi.DAL;

namespace SyntPolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService providerService;
        private readonly IMapper mapper;

        public ProvidersController(IProviderService service, IMapper mapper)
        {
            providerService = service;
            this.mapper = mapper;
        }

        // GET: api/Providers
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Provider>>> GetProviders()
        {
            var providers = await providerService.GetAsync();
            if (providers == null)
            {
                return NotFound();
            }
            return Ok(providers);
        }

        // GET: api/Providers
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Provider>>> GetAllProviders()
        {
            var providers = await providerService.GetAllAsync();

            if (providers == null)
            {
                return NotFound();
            }

            return Ok(providers);
        }

        // GET: api/Providers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provider>> GetProvider(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var provider = await providerService.GetByIdAsync(id);

            if (provider == null)
            {
                return NotFound();
            }

            return Ok(provider);
        }

        // GET: api/Providers/5
        [HttpGet("all/{id}")]
        public async Task<ActionResult<Provider>> GetDeletedProvider(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var provider = await providerService.GetDeletedByIdAsync(id);

            if (provider == null)
            {
                return NotFound();
            }

            return Ok(provider);
        }

        // PUT: api/Providers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvider(int id, [FromBody]PostProviderDTO provider)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var providerToBeUpdated = await providerService.GetDeletedByIdAsync(id);

            if (providerToBeUpdated == null)
            {
                return NotFound();
            }
            var mappedProvider = mapper.Map<PostProviderDTO, Provider>(provider);
            await providerService.UpdateProvider(providerToBeUpdated, mappedProvider);

            var newProvider = await providerService.GetDeletedByIdAsync(id);
            return Ok(newProvider);
        }

        // POST: api/Providers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Provider>> PostProvider([FromBody] PostProviderDTO provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var mappedProvider = mapper.Map<PostProviderDTO, Provider>(provider);
            await providerService.CreateProvider(mappedProvider);

            return Ok();
        }

        // DELETE: api/Providers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Provider>> DeleteProvider(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var providerToBeDeleted = await providerService.GetDeletedByIdAsync(id);

            if (providerToBeDeleted == null)
            {
                return NotFound();
            }
            await providerService.DeleteProvider(id);

            return NoContent();
        }
    }
}
