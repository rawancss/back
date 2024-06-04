using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiWithJWT.Models
{


	public class OrderItem
	{
		[Key]
		public Guid OrderItemId { get; set; }

		public Guid OrderId { get; set; }

		public Guid ProductId { get; set; }

		public int Quantity { get; set; }

		[Column(TypeName = "decimal(10, 2)")]
		public decimal Price { get; set; }

		[ForeignKey("OrderId")]
		public  Order Order { get; set; }

		[ForeignKey("ProductId")]

		public virtual Product Product { get; set; }

	}
}