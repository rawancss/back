using ApiWithJWT.Dtos.Categories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApiWithJWT.Models;
using ApiWithJWT.Dtos.Carts;

namespace ApiWithJWT.Dtos.Products;

public class ProductDto
{

	public Guid ProductId { get; set; }


	public required string Name { get; set; }
	public required string Image { get; set; }

	public required string Description { get; set; }


	public decimal Price { get; set; }

	public int QuantityAvailable { get; set; }

	// Foreign key property for category
	public Guid CategoryId { get; set; }

	public string Category { get; set; }
	// Foreign key property for subcategory
	
// public CartDto Cart { get; set; }
// 	public Guid? CartId { get; set; }
}
