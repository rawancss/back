using Microsoft.AspNetCore.Identity;

namespace ApiWithJWT.Models;

public class Account:IdentityUser<Guid>
{
	public string Name { get; set; }
	
	public bool IsAdmin {get; set;}

}
