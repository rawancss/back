using ApiWithJWT.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiWithJWT.Dtos.Payments;

public class PaymentDto
{
	public Guid PaymentId { get; set; }
	public Guid OrderId { get; set; }

	public decimal Amount { get; set; }

	public DateTime PaymentDate { get; set; }

	public  string PaymentMethod { get; set; }

	public  Order Order { get; set; }
}
