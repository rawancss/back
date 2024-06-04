
using ApiWithJWT.Dtos;
using ApiWithJWT.Dtos.Products;
using ApiWithJWT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithJWT.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
  


	public ProductController(IProductService productService, ICategoryService categoryService)
	{
		_productService = productService;
		_categoryService = categoryService;
	
	}



	[HttpGet]
    public async Task<IActionResult> GetAllProductsService(
        [FromQuery] int page = 1,
        [FromQuery] int limit = 5,
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? sortBy = null
    )
    {
        try
        {
            var products = await _productService.GetAllProductsService(
                page,
                limit,
                searchTerm,
                sortBy
            );

          

        return ApiResponse.Success(products, "All Products Returned Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to get all products");
            return ApiResponse.ServerError(ex.Message);
        }
    }

    [HttpGet("{ProductId:guid}")]
    public async Task<IActionResult> GetProductByIdService(Guid ProductId)
    {
        try
        {
            var product = await _productService.GetProductByIdService(ProductId);

            if (product != null)
            {
                return ApiResponse.Success(product, "Product Found Successfully");
            }
            else
            {
                return ApiResponse.NotFound("Product Not Found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to get the product: " + ex.Message);
            return ApiResponse.ServerError("An error occurred while retrieving the product.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddProductService([FromBody] CreateProductDto productModel)
    {
        try
        {
            var category = await _categoryService.GetByIdAsync(productModel.CategoryId);
   
			if (category is null)
            {
				return ApiResponse.NotFound("Category Not Found");
            }
           

            


            var createdProduct = await _productService.AddProductService(productModel);

            if (createdProduct != null)
            {
                return ApiResponse.Created(createdProduct, "Product created successfully");
            }
            else
            {
                return ApiResponse.BadRequest("Failed to create product");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to create product: " + ex.Message);
            return ApiResponse.ServerError("An error occurred while creating the product.");
        }
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        try
        {
            var isDeleted = await _productService.DeleteProductService(productId);
            if (isDeleted)
            {
                return NoContent(); // Product successfully deleted
            }

            return NotFound("Product not found");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to delete product: " + ex.Message);
            return ApiResponse.ServerError("An error occurred while deleting the product.");
        }
    }
}
