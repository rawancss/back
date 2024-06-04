using Microsoft.AspNetCore.Identity;

namespace ApiWithJWT.Models;

public class Role(string name):IdentityRole<Guid>(name)
{

}
