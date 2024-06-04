using ApiWithJWT.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.OrderItems;

public class OrderItemDto
{

	public Guid OrderItemId { get; set; }

	public Guid OrderId { get; set; }

	public Guid ProductId { get; set; }

	public int Quantity { get; set; }

	public decimal Price { get; set; }

	public Order Order { get; set; }

	public Product Product { get; set; }
}
