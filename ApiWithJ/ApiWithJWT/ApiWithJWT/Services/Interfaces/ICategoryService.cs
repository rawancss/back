using ApiWithJWT.Dtos.Categories;

namespace ApiWithJWT.Services.Interfaces;
public interface ICategoryService
{
    Task<Guid> AddAsync(CreateCategoryDto categoryModel);
    Task<bool> DeleteAsync(Guid categoryId);
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(Guid categoryId);
    Task<bool> UpdateAsync(Guid id, UpdateCategoryDto categoryModel);
}