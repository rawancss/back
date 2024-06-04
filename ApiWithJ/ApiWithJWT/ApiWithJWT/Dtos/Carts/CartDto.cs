using ApiWithJWT.Dtos.Products;
using ApiWithJWT.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.Carts;

public class CartDto
{
	public Guid CartId { get; set; }

	public int Quantity { get; set; }
	public Customer Customer { get; set; }
	public Guid CustomerId { get; set; }//1-1

	public List<ProductDto>? Products { get; set; }//1-many
}
