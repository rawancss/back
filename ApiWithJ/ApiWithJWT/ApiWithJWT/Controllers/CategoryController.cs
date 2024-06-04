using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Categories;
using ApiWithJWT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithJWT.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        // GET: api/category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult<Guid>> AddCategory(CreateCategoryDto categoryModel)
        {
            var categoryId = await _categoryService.AddAsync(categoryModel);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryId }, categoryId);
        }

        // PUT: api/category/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id,UpdateCategoryDto categoryModel)
        {
			var result = await _categoryService.UpdateAsync(id, categoryModel);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/category/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
