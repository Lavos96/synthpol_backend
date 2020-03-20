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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            productService = service;
            this.mapper = mapper;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var product = await productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/Products/5
        [HttpGet("all/{id}")]
        public async Task<ActionResult<Product>> GetDeletedProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var product = await productService.GetDeletedByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await productService.GetAsync();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET: api/products/category/{id}
        [HttpGet("category/{catId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsFromCategory(int catId)
        {
            var products = await productService.GetProductsByCategoryAsync(catId);
            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(mappedProducts);
        }

        // GET: api/products/provider/{id}
        [HttpGet("provider/{provId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsFromProvider(int provId)
        {
            var products = await productService.GetProductsByProviderAsync(provId);
            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(mappedProducts);
        }

        // GET: api/products/category/{catId}/provider/{provId}
        [HttpGet("category/{catId}/provider/{provId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsFromCategoryAndProvider(int catId, int provId)
        {
            var products = await productService.GetProductsByCategoryAndProviderAsync(catId, provId);
            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(mappedProducts);
        }

        // GET: api/products/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await productService.GetAllAsync();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET: api/products/all/category/{id}
        [HttpGet("all/category/{catId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsFromCategory(int catId)
        {
            var products = await productService.GetAllProductsByCategoryAsync(catId);
            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(mappedProducts);
        }

        // GET: api/products/all/provider/{id}
        [HttpGet("all/provider/{provId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsFromProvider(int provId)
        {
            var products = await productService.GetAllProductsByProviderAsync(provId);
            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(mappedProducts);
        }

        // GET: api/products/all/category/{catId}/provider/{provId}
        [HttpGet("all/category/{catId}/provider/{provId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsFromCategoryAndProvider(int catId, int provId)
        {
            var products = await productService.GetAllProductsByCategoryAndProviderAsync(catId, provId);
            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(mappedProducts);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId || id == 0)
            {
                return BadRequest();
            }

            var productToBeUpdated = await productService.GetDeletedByIdAsync(id);

            if (productToBeUpdated == null)
            {
                return NotFound();
            }
            await productService.UpdateProduct(productToBeUpdated, product);

            var newProduct = await productService.GetDeletedByIdAsync(id);
            return Ok(newProduct);
        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await productService.CreateProduct(product);

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var productToBeDeleted = await productService.GetDeletedByIdAsync(id);

            if (productToBeDeleted == null)
            {
                return NotFound();
            }
            await productService.DeleteProduct(id);

            return NoContent();
        }
    }
}
