using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.Carts;

public class CreateCartDto
{
	[Required]
	public int Quantity { get; set; }
	public Guid CustomerId { get; set; }//1-1
}
