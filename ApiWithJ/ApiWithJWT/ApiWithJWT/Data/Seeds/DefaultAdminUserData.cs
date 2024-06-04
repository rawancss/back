using ApiWithJWT.Models;
using Microsoft.AspNetCore.Identity;


namespace ApiWithJWT.Data.Seeds;

public class DefaultAdminUserData
{
	public static async Task SeedAsync(UserManager<Account> userManager)
	{

		var defaultUser = new Account
		{
			UserName = "Rawan",
			Email = "Rawan@gmail.com",
			Name = "Rawan",
			PhoneNumber = "7568464836475",
			EmailConfirmed = true,
			PhoneNumberConfirmed = true,
			IsAdmin=true
		};

		if (userManager.Users.All(u => u.Id != defaultUser.Id))
		{
			var user = await userManager.FindByEmailAsync(defaultUser.Email);
			if (user == null)
			{
				await userManager.CreateAsync(defaultUser, "qweasd");
				await userManager.AddToRoleAsync(defaultUser, "Admin");
			}

		}
	}
}
