using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.ViewComponents
{
    //Ana sayfada bütün kitapların tablo halinde render edilmesini sağlayacak olan component
    public class AllBooksComponent : ViewComponent
    {
        //Dependency injection
        private readonly IBookService _bookService;
        public AllBooksComponent(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Book> books= _bookService.ReadAll();
            return View(books);
        }
    }
}
