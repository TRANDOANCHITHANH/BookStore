using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BookStore.Repositories
{
    public class HomeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void GetBooks(string keySearch = "",int theLoaiId = 0)
        {
            //sang dang thuong
            keySearch = keySearch.ToLower();
            var sachs = (from sach in _dbContext.Books
                         join theLoai in _dbContext.Genres
                         on sach.GenreId equals theLoai.Id
                         select new Book
                         {
                             Id = sach.Id,
                             Image = sach.Image,
                             AuthorName = sach.AuthorName,
                             Description = sach.Description,
                             Price = sach.Price,
                             GenreId = sach.GenreId,
                             GenreName = sach.GenreName,    
                         }
                         );
            
        }
        public async Task<IEnumerable<Book>>GetInfBook(string keySearch="",int theLoaiId = 0)
        {
            //sang dang thuong
            keySearch = keySearch.ToLower();
            IEnumerable<Book> sachs = await (from sach in _dbContext.Books
                         join theLoai in _dbContext.Genres
                         on sach.GenreId equals theLoai.Id
                         where string.IsNullOrWhiteSpace(keySearch)  
                         || (sach != null && sach.BookName.ToLower().StartsWith(keySearch))
                         select new Book
                         {
                             Id = sach.Id,
                             Image = sach.Image,
                             AuthorName = sach.AuthorName,
                             Description = sach.Description,
                             Price = sach.Price,
                             GenreId = sach.GenreId,
                             GenreName = sach.GenreName,
                         }
                         ).ToListAsync();
            return sachs;
        }
    }
}
