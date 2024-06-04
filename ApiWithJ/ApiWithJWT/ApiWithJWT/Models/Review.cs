using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiWithJWT.Models
{
	public class Review
	{
		[Key]
		public Guid ReviewId { get; set; }

		public Guid ProductId { get; set; }

		public Guid CustomerId { get; set; }

		public int Rating { get; set; }

		public  string Comment { get; set; }

		[ForeignKey("ProductId")]
		public  Product Product { get; set; }

		[ForeignKey("CustomerId")]
		public  Customer Customer { get; set; }


	}
}