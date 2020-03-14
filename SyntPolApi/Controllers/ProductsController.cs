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
    public class ProductsController : ControllerBase
    {
        private readonly SyntPolDbContext _context;

        public ProductsController(SyntPolDbContext context)
        {
            _context = context;
        }


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null || !product.ShallDisplay)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products/5
        [HttpGet("all/{id}")]
        public async Task<ActionResult<Product>> GetDeletedProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.Where(p => p.ShallDisplay).ToListAsync();
        }

        // GET: api/products/category/{id}
        [HttpGet("category/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsFromCategory(int id)
        {
            List<Product> products = await _context.Products
                .Where(s => s.ShallDisplay)
                .Where(c => c.CategoryId == id)
                .Select(p => new Product() 
                { 
                    ProductId = p.ProductId,
                    Name = p.Name,
                    VAT = p.VAT,
                    NettoPrice = p.NettoPrice,
                    Description = p.Description,
                    PhotoString = p.PhotoString,
                    ShallDisplay = p.ShallDisplay,
                    ProviderId = p.ProviderId,
                    CategoryId = p.CategoryId,
                    Category = p.Category
                })
                .ToListAsync();

            return products;
        }

        // GET: api/products/provider/{id}
        [HttpGet("provider/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsFromProvider(int id)
        {
            var products = await _context.Products
                .Where(s => s.ShallDisplay)
                .Where(prov => prov.ProviderId == id)
                .Select(p => new Product()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    VAT = p.VAT,
                    NettoPrice = p.NettoPrice,
                    Description = p.Description,
                    PhotoString = p.PhotoString,
                    ShallDisplay = p.ShallDisplay,
                    ProviderId = p.ProviderId,
                    Provider = p.Provider,
                    CategoryId = p.CategoryId,
                })
                .ToListAsync();

            return products;
        }

        // GET: api/products/category/{catId}/provider/{provId}
        [HttpGet("category/{catId}/provider/{provId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsFromCategoryAndProvider(int catId, int provId)
        {
            var products = await _context.Products
                .Where(s => s.ShallDisplay)
                .Where(c => c.CategoryId == catId)
                .Where(prov => prov.ProviderId == provId)
                .Select(p => new Product()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    VAT = p.VAT,
                    NettoPrice = p.NettoPrice,
                    Description = p.Description,
                    PhotoString = p.PhotoString,
                    ShallDisplay = p.ShallDisplay,
                    ProviderId = p.ProviderId,
                    Provider = p.Provider,
                    CategoryId = p.CategoryId,
                    Category = p.Category
                })
                .ToListAsync();

            return products;
        }

        // GET: api/products/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/products/all/category/{id}
        [HttpGet("all/category/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsFromCategory(int id)
        {
            List<Product> products = await _context.Products
                .Where(c => c.CategoryId == id)
                .Select(p => new Product()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    VAT = p.VAT,
                    NettoPrice = p.NettoPrice,
                    Description = p.Description,
                    PhotoString = p.PhotoString,
                    ShallDisplay = p.ShallDisplay,
                    ProviderId = p.ProviderId,
                    CategoryId = p.CategoryId,
                    Category = p.Category
                })
                .ToListAsync();

            return products;
        }

        // GET: api/products/all/provider/{id}
        [HttpGet("all/provider/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsFromProvider(int id)
        {
            var products = await _context.Products
                .Where(prov => prov.ProviderId == id)
                .Select(p => new Product()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    VAT = p.VAT,
                    NettoPrice = p.NettoPrice,
                    Description = p.Description,
                    PhotoString = p.PhotoString,
                    ShallDisplay = p.ShallDisplay,
                    ProviderId = p.ProviderId,
                    Provider = p.Provider,
                    CategoryId = p.CategoryId,
                })
                .ToListAsync();

            return products;
        }

        // GET: api/products/all/category/{catId}/provider/{provId}
        [HttpGet("all/category/{catId}/provider/{provId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsFromCategoryAndProvider(int catId, int provId)
        {
            var products = await _context.Products
                .Where(c => c.CategoryId == catId)
                .Where(prov => prov.ProviderId == provId)
                .Select(p => new Product()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    VAT = p.VAT,
                    NettoPrice = p.NettoPrice,
                    Description = p.Description,
                    PhotoString = p.PhotoString,
                    ShallDisplay = p.ShallDisplay,
                    ProviderId = p.ProviderId,
                    Provider = p.Provider,
                    CategoryId = p.CategoryId,
                    Category = p.Category
                })
                .ToListAsync();

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        
        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.ShallDisplay = false;
            await TryUpdateModelAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
