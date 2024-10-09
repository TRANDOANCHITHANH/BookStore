
using Microsoft.AspNetCore.Identity;
using BookStore.Const;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace BookStore.Data
{
	public class DataSeed
	{
		public static async Task KhoiTaoDuLieuMacDinh(IServiceProvider dichVu)
		{
			var quanLyNguoiDung = dichVu.GetService<UserManager<IdentityUser>>();
			var quanLyVaiTro = dichVu.GetService<RoleManager<IdentityRole>>();

			
			await quanLyVaiTro.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
			await quanLyVaiTro.CreateAsync(new IdentityRole(Roles.User.ToString()));

			
			var quanTri = new IdentityUser
			{
				UserName = "admin@test.xyz",
				Email = "admin@test.xyz",
				EmailConfirmed = true
			};

			var nguoiDungTrongCsdl = await quanLyNguoiDung.FindByEmailAsync(quanTri.Email);

			
			if (nguoiDungTrongCsdl is null)
			{
				// Tạo tài khoản Admin với mật khẩu là Admin12345!@#$%
				var ketQua = await quanLyNguoiDung.CreateAsync(quanTri, "Admin12345!@#$%");

				// Nếu tạo thành công thì thêm vai trò người dùng
				if (ketQua.Succeeded)
				{
					await quanLyNguoiDung.AddToRoleAsync(quanTri, Roles.Admin.ToString());
				}
				else
				{
					// In ra mã lỗi
					foreach (var error in ketQua.Errors)
					{
						Console.WriteLine(error.Description);
					}
				}
			}
		}
	}
}