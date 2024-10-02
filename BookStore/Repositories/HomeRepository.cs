using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
		public async Task<IEnumerable<Genre>> Genres()
		{
			return await _dbContext.Genres.ToListAsync();
		}
		public async Task<IEnumerable<Book>> GetBooks(string keySearch = "", int genreId = 0)
		{
			// chuyển đổi chuỗi sang dạng chữ thường
			keySearch = keySearch.ToLower();

			IEnumerable<Book> books =
			  await (from book in _dbContext.Books
					 join genre in _dbContext.Genres
					 on book.GenreId equals genre.Id
					 where string.IsNullOrWhiteSpace(keySearch) || (book != null && book.BookName != null && book.BookName.ToLower().StartsWith(keySearch.ToLower()))
					 select new Book
					 {
						 Id = book.Id,
						 //Image = book.Image,
						 AuthorName = book.AuthorName,
						 BookName = book.BookName,
						 GenreId = book.GenreId,
						 Price = book.Price,
						 //GenreName = genre.GenreName
					 }
					 ).ToListAsync();
			if (genreId > 0)
			{
				books = books.Where(i => i.GenreId == genreId).ToList();
			}
			return books;
		}
	}
}
