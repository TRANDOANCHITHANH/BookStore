using BookStore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Data
{
	public class DataSeed
	{
		public static async Task InitData(IServiceProvider service)
		{
			var mnUser = service.GetService<UserManager<IdentityUser>>();
			var mnRole = service.GetService<RoleManager<IdentityRole>>();
			//Them vai tro
			await mnRole.CreateAsync(new IdentityRole(PhanQuyen.Admin.ToString()));
			await mnRole.CreateAsync(new IdentityRole(PhanQuyen.User.ToString()));

			//Tao thong tin mac dinh cho acc admin
			var ad = new IdentityUser
			{
				UserName = "admin@gmail.com",
				Email = "admin@gmail.com",
				EmailConfirmed = true
			};
			var userDb = await mnUser.FindByEmailAsync(ad.Email);
			if(userDb is null)
			{
				var ketqua = await mnUser.CreateAsync(ad, "Admin12345@");
				if(ketqua.Succeeded) {
				await mnUser.AddToRoleAsync(ad,PhanQuyen.Admin.ToString());
				}
			else
				{
					foreach (var loi in ketqua.Errors)
					{
						Console.WriteLine(loi.Description);
					}
				}
				
			}
			
		}
	}
}
