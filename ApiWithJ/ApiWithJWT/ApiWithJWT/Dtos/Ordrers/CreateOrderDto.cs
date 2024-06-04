using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApiWithJWT.Dtos.ShippingAddress;

namespace ApiWithJWT.Dtos.Ordrers;

public class CreateOrderDto
{
	public Guid CustomerId { get; set; }


	[Column(TypeName = "decimal(10, 2)")]
	public decimal TotalPrice { get; set; }

	[MaxLength(50)]
	public  string Status { get; set; }

	public CreateShippingAddress Address { get; set; }
}
