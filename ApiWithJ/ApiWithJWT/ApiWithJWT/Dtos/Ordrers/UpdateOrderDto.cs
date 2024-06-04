using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.Ordrers;

public class UpdateOrderDto
{
	public Guid CustomerId { get; set; }
	public DateTime OrderDate { get; set; }

	[Column(TypeName = "decimal(10, 2)")]
	public decimal TotalPrice { get; set; }

	[MaxLength(50)]
	public required string Status { get; set; }
	public Guid AddressId { get; set; }
}
