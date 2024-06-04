using ApiWithJWT.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApiWithJWT.Dtos.Users;

namespace ApiWithJWT.Dtos.ShippingAddress;

public class ShippingAddressDto
{

	public Guid AddressId { get; set; }

	public Guid CustomerId { get; set; }

	public string AddressLine1 { get; set; } = string.Empty;
	public  string City { get; set; }

	public  string State { get; set; }

	public required string Country { get; set; }

	public required CustomerDto Customer { get; set; }
}
