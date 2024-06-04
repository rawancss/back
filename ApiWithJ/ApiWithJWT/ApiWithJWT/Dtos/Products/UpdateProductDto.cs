using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.Products;

public class UpdateProductDto
{
	[Required]
	[MaxLength(100)]
	public required string Name { get; set; }
public required string Image { get; set; }
	public required string Description { get; set; }

	[Column(TypeName = "decimal(10, 2)")]
	public decimal Price { get; set; }

	// Foreign key property for category
	public Guid CategoryId { get; set; }


	// public Guid? CartId { get; set; }
}
