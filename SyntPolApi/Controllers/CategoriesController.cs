using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SyntPolApi.Core.DTOs;
using SyntPolApi.Core.Models;
using SyntPolApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await categoryService.GetAsync();
            if(categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        // GET: api/Categories/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await categoryService.GetAllAsync();

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var category = await categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // GET: api/Categories/5
        [HttpGet("all/{id}")]
        public async Task<ActionResult<Category>> GetDeletedCategory(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var category = await categoryService.GetDeletedByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody]PostCategoryDTO category)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var categoryToBeUpdated = await categoryService.GetDeletedByIdAsync(id);

            if(categoryToBeUpdated == null)
            {
                return NotFound();
            }
            var mappedCategory = mapper.Map<PostCategoryDTO, Category>(category);
            await categoryService.UpdateCategory(categoryToBeUpdated, mappedCategory);

            var newCategory = await categoryService.GetDeletedByIdAsync(id);
            return Ok(newCategory);
        }

        // POST: api/Categories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("")]
        public async Task<ActionResult<Category>> PostCategory([FromBody]PostCategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var mappedCategory = mapper.Map<PostCategoryDTO, Category>(category);

            await categoryService.CreateCategory(mappedCategory);
            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var categoryToBeDeleted = await categoryService.GetDeletedByIdAsync(id);

            if (categoryToBeDeleted == null)
            {
                return NotFound();
            }
            await categoryService.DeleteCategory(id);

            return NoContent();
        }
    }
}
