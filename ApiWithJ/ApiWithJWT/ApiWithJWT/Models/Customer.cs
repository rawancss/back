using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWithJWT.Models;

public class Customer : Account
{


	public List<Order> Orders { get; set; }
}
