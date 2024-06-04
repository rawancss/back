using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiWithJWT.Models;

public class Order
{
	[Key]
	public Guid OrderId { get; set; }

	public Guid CustomerId { get; set; }
	public DateTime OrderDate { get; set; }

	[Column(TypeName = "decimal(10, 2)")]
	public decimal TotalPrice { get; set; }

	[MaxLength(50)]
	public  string Status { get; set; }

	public Guid AddressId { get; set; }

	[ForeignKey("CustomerId")]
	public  Customer Customer { get; set; }

	[ForeignKey("AddressId")]
	public  ShippingAddress ShippingAddress { get; set; }
}
