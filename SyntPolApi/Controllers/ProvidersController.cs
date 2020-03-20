﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public ProvidersController(IProviderService service)
        {
            providerService = service;
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
        public async Task<IActionResult> PutProvider(int id, Provider provider)
        {
            if (id != provider.ProviderId || id == 0)
            {
                return BadRequest();
            }

            var providerToBeUpdated = await providerService.GetDeletedByIdAsync(id);

            if (providerToBeUpdated == null)
            {
                return NotFound();
            }
            await providerService.UpdateProvider(providerToBeUpdated, provider);

            var newProvider = await providerService.GetDeletedByIdAsync(id);
            return Ok(newProvider);
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
            await providerService.CreateProvider(provider);

            return CreatedAtAction("GetProvider", new { id = provider.ProviderId }, provider);
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
