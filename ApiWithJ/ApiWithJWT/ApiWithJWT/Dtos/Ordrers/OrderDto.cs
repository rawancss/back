using ApiWithJWT.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApiWithJWT.Dtos.ShippingAddress;

namespace ApiWithJWT.Dtos.Ordrers;

public class OrderDto
{
	public Guid OrderId { get; set; }

	public Guid CustomerId { get; set; }
	public Customer Customer { get; set; }
	public ShippingAddressDto ShippingAddress { get; set; }
	public Guid AddressId { get; set; }


	public DateTime OrderDate { get; set; }


	public decimal TotalPrice { get; set; }


	public  string Status { get; set; }


}
