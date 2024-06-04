
using ApiWithJWT.Data;
using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Categories;
using ApiWithJWT.Dtos.Products;
using ApiWithJWT.Models;
using ApiWithJWT.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiWithJWT.Services;

public class ProductService : IProductService
{
	private readonly ApplicationDbContext _dbContext;

	public ProductService(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<PagedResult<ProductDto>> GetAllProductsService(
		int page = 3, int limit = 6, string? searchTerm = null, string? sortBy = null
		)
	{
		var skip = (page - 1) * limit;

		IQueryable<Product> query = _dbContext.Products;


		if (!string.IsNullOrEmpty(searchTerm))
		{
			query = query.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()));
		}

		var totalRecoreds = query.Count();
		var totalPages = (int)Math.Ceiling((double)totalRecoreds/limit);

		if (!string.IsNullOrEmpty(sortBy))
		{
			switch (sortBy.ToLower())
			{
				case "name":
					query = query.OrderBy(p => p.Name);
					break;
				case "price":
					query = query.OrderBy(p => p.Price);
					break;
				case "category":
					query = query.OrderBy(p => p.Category.Name);
					break;
				default:
					query = query.OrderBy(p => p.ProductId);
					break;
			}
		}
		query = query.Include(p => p.Category)
					 .Skip(skip)
					 .Take(limit);


		return new PagedResult<ProductDto>
		{
			TotalRecords = totalRecoreds,
			TotalPages = totalPages,
			Data = await query.Select(product => new ProductDto
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Image = product.Image,
				Price = product.Price,
				CategoryId = product.CategoryId,
				Category = product.Category.Name,
				Description = product.Description,
				QuantityAvailable = product.QuantityAvailable

			}).ToListAsync()
		};
	}



	public async Task<ProductDto?> GetProductByIdService(Guid ProductId)
	{
		var product = await _dbContext.Products
			.Include(p => p.Category)
			.FirstOrDefaultAsync(p => p.ProductId == ProductId);

		return new ProductDto
		{
			ProductId = product.ProductId,
			Name = product.Name,
			Image = product.Image,
			Price = product.Price,
			CategoryId = product.CategoryId,
			Category = product.Category.Name,
			Description = product.Description,
			QuantityAvailable = product.QuantityAvailable
		};
	}

	public async Task<ProductDto> AddProductService(CreateProductDto newProduct)
	{
		var existingCategory = _dbContext.Categories.Find(newProduct.CategoryId);


		var product = new Product
		{
			ProductId = Guid.NewGuid(),
			Name = newProduct.Name,
			Price = newProduct.Price,
			Description = newProduct.Description,
			Image = newProduct.Image,
			CategoryId = newProduct.CategoryId,

		};


		_dbContext.Products.Add(product);
		await _dbContext.SaveChangesAsync();

		return new ProductDto
		{
			ProductId = product.ProductId,
			Name = newProduct.Name,
			Image = product.Image,
			Price = newProduct.Price,
			CategoryId = newProduct.CategoryId,
			Description = newProduct.Description,
		};
	}



	public async Task<ProductDto?> UpdateProductService(Guid productId, UpdateProductDto updatedProduct)
	{
		var existingProduct = await _dbContext.Products.FindAsync(productId);
		if (existingProduct != null)
		{
			existingProduct.Name = updatedProduct.Name ?? existingProduct.Name;
			existingProduct.Description = updatedProduct.Description ?? existingProduct.Description;
			existingProduct.Price = updatedProduct.Price;
			existingProduct.CategoryId = updatedProduct.CategoryId;


			await _dbContext.SaveChangesAsync();
		}

		return new ProductDto
		{
			ProductId = existingProduct.ProductId,
			Name = existingProduct.Name,
			Image = existingProduct.Image,
			Price = existingProduct.Price,
			CategoryId = existingProduct.CategoryId,

			Description = existingProduct.Description,
			QuantityAvailable = existingProduct.QuantityAvailable

		};
	}
	public async Task<bool> DeleteProductService(Guid productId)
	{
		var existingProduct = await _dbContext.Products.FindAsync(productId);
		if (existingProduct != null)
		{
			_dbContext.Products.Remove(existingProduct);
			await _dbContext.SaveChangesAsync();
			return true;
		}
		return false;
	}
}