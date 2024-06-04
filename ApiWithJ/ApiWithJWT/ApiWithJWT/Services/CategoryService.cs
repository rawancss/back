
using ApiWithJWT.Data;
using ApiWithJWT.Dtos.Categories;
using ApiWithJWT.Models;
using ApiWithJWT.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ApiWithJWT.Services
{	public class CategoryService : ICategoryService
	{
		private readonly ApplicationDbContext _dbContext;
		public CategoryService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		// Create (Add)
		public async Task<Guid> AddAsync(CreateCategoryDto categoryModel)
		{
			var category = new Category { CategoryId = Guid.NewGuid(), Name = categoryModel.Name };

			await _dbContext.Categories.AddAsync(category);
			await _dbContext.SaveChangesAsync();

			return category.CategoryId;
		}

		// Read (Get All)
		public async Task<List<CategoryDto>> GetAllAsync()
		{
			return await _dbContext
				.Categories.Select(c => new CategoryDto
				{
					CategoryId = c.CategoryId,
					Name = c.Name
				})
				.ToListAsync();
		}

		// Read (Get by ID)
		public async Task<CategoryDto> GetByIdAsync(Guid categoryId)
		{
			var category =
				await _dbContext.Categories.FirstOrDefaultAsync(x=> x.CategoryId == categoryId)
				?? throw new Exception($"Category with ID : {categoryId} is not found");
			return new CategoryDto
			{
				CategoryId = category.CategoryId,
				Name = category.Name,
			
			};
		}

		// Update
		public async Task<bool> UpdateAsync(Guid id, UpdateCategoryDto categoryDto)
		{
			var category = await _dbContext.Categories.FindAsync(id);
			if (category == null)
				return false;

			category.Name = categoryDto.Name;
			await _dbContext.SaveChangesAsync();
			return true;
		}

		// Delete
		public async Task<bool> DeleteAsync(Guid categoryId)
		{
			var category = await _dbContext.Categories.FindAsync(categoryId);
			if (category == null)
				return false;

			_dbContext.Categories.Remove(category);
			await _dbContext.SaveChangesAsync();
			return true;
		}
	}
}
