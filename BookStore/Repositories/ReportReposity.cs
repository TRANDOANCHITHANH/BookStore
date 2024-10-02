using BookStore.Data;
using BookStore.Models;
using BookStore.Models.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Book>> LayThongTinBanSanPhamTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc);
    }
    public class ReportReposity : IReportRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReportReposity(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ResultBookModel>> LayThongTinBanSanPhamTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            // Khai báo các SqlParameter với giá trị của tham số phương thức (tham số hàm hay tham số truyền vào)
            var paramNgayBatDau = new SqlParameter("@ngayBatDau", ngayBatDau);
            var paramNgayKetThuc = new SqlParameter("@ngayKetThuc", ngayKetThuc);
            // Thực thi câu lệnh SQL và lấy kết quả
            var result = await _dbContext.Database.SqlQueryRaw<ResultBookModel>(
                "exec Usp_GetResultBookByDate @ngayBatDau, @ngayKetThuc",
                paramNgayBatDau, paramNgayKetThuc
            ).ToListAsync();
            return result;
        }
        Task<IEnumerable<Book>> IReportRepository.LayThongTinBanSanPhamTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            throw new NotImplementedException();
        }
    }
}
