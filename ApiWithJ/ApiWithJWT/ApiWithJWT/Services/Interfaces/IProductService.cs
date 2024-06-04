using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Products;
using ApiWithJWT.Models;

namespace ApiWithJWT.Services.Interfaces;
public interface IProductService
{
    Task<ProductDto> AddProductService(CreateProductDto newProduct);
    Task<bool> DeleteProductService(Guid productId);
    Task<PagedResult<ProductDto>> GetAllProductsService(int page = 1, int limit = 3, string? searchTerm = null, string? sortBy = null);
    Task<ProductDto?> GetProductByIdService(Guid ProductId);
    Task<ProductDto?> UpdateProductService(Guid productId, UpdateProductDto updatedProduct);
}