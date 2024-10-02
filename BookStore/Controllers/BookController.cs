using BookStore.Models.DTOs;
using BookStore.Repositories;
using BookStore.Repositories.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IFileService _fileService;
        public async Task <IActionResult> Index()
        {
            var books = await _bookRepository.GetBooks();
            return View(books);
        }
        public async Task<IActionResult> AddBook()
        {
            var selectGenre = (await _genreRepository.GetGenres()).Select(theLoai => new SelectListItem
            {
                Text = theLoai.GenreName,
                Value = theLoai.Id.ToString()
            });
            BookDTO bookDTO = new()
            {
                GenreList = selectGenre
            };
            return View(bookDTO);
        }
    }
}
