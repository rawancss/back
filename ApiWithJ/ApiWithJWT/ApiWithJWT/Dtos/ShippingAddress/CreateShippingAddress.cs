namespace ApiWithJWT.Dtos.ShippingAddress;

public class CreateShippingAddress
{
	public Guid CustomerId { get; set; }

	public string AddressLine1 { get; set; } = string.Empty;
	public string City { get; set; }

	public string State { get; set; }
	public required string Country { get; set; }
}
