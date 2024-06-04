using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.Categories;

public class UpdateCategoryDto
{

	[MaxLength(100)]
	public string Name { get; set; }
}
