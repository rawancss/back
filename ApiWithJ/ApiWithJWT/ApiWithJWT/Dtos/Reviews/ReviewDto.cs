using ApiWithJWT.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.Reviews;

public class ReviewDto
{

	public Guid ReviewId { get; set; }

	public Guid ProductId { get; set; }

	public Guid CustomerId { get; set; }

	public int Rating { get; set; }

	public  string Comment { get; set; }

	public  Product Product { get; set; }

	public  Account User { get; set; }
}
