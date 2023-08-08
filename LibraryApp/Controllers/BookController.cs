using BusinessLayer.Abstract;
using EntityLayer;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        //Dependency injection
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookViewModel bookViewModel, IFormFile kitapGorsel)
        {
            Book book = new Book()
            {
                BookName = bookViewModel.BookName,
                BookAuthor = bookViewModel.BookAuthor,
                IsInLibrary = true
            };
            
            book.ImageUrl = "images/Books/" + await _bookService.GorselOlustur(kitapGorsel);

            if(!await _bookService.BookExistControl(book))
            {
                ViewBag.error = "Bu kitap zaten kayıtlı.";
                return View();
            }
            
            if (await _bookService.AddEntity(book))
            {
                TempData["success"] = "Yeni kitap kaydı başarıyla yapıldı.";
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.error = "Yeni kitap kaydı yapılırken bir hata oluştu.";
                return View();
            }
        }
    }
}
