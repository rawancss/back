using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWithJWT.Models
{
	public class Product
	{
		[Key]
		public Guid ProductId { get; set; }

		[Required]
		[MaxLength(100)]
		public  string Name { get; set; }
        public  string Image { get; set; }
		public string? Description { get; set; }

		[Column(TypeName = "decimal(10, 2)")]
		public decimal Price { get; set; }

		public int QuantityAvailable { get; set; }

		//Foreign key property for Category
		public Guid CategoryId { get; set; }

		// Navigation property for category
		[ForeignKey("CategoryId")]
		public virtual Category? Category { get; set; }

		// public Guid? CartId { get; set; }

		// [ForeignKey("CartId")]
		// public virtual Cart? Cart { get; set; }

		public virtual IEnumerable<OrderItem> OrderItem { get; set; }
	}
}
