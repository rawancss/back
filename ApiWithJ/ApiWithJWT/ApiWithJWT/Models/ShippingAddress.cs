using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiWithJWT.Models
{

	public class ShippingAddress
	{
		[Key]
		public Guid AddressId { get; set; }

		public Guid CustomerId { get; set; }

		[MaxLength(100)]
		public string AddressLine1 { get; set; } = string.Empty;
		public string City { get; set; }

		[MaxLength(50)]
		public string State { get; set; }

		[MaxLength(50)]
		public string Country { get; set; }

		[ForeignKey("CustomerId")]
		public Customer Customer { get; set; }
	}
}
