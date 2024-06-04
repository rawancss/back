using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWithJWT.Models;

public class Category
{
	[Key]
	public Guid CategoryId { get; set; }

	[MaxLength(100)]
	public  string Name { get; set; }
	public List<Product>? Products { get; set; }
}
