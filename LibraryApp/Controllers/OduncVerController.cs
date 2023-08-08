using BusinessLayer.Abstract;
using EntityLayer;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class OduncVerController : Controller
    {
        //Dependency injection
        private readonly IStudentService _studentService;
        private readonly IBookService _bookService;

        public OduncVerController(IStudentService studentService, IBookService bookService)
        {
            _studentService = studentService;
            _bookService = bookService;
        }

        public IActionResult Index(int id)
        {
            var _book = _bookService.ReadOne(id);

            //Gönderilen istekte veritabanında kayıtlı olmayan bir kitap id bilgisi parametre olarak gönderilirse,
            //kitabın bulunamadığıyla alakalı hata mesajı ViewBag aracılığıyla view'e taşınır.
            if (_book == null)
            {
                ViewBag.error = "İlgili kitap bulunamadı.";
                return View();
            }

            //Gönderilen istekte herhangi bir öğrencide olan bir kitap id bilgisi parametre olarak gönderilirse,
            //kitabın bir öğrencide olduğuyla alakalı hata mesajı ViewBag aracılığıyla view'e taşınır.
            if (!_book.IsInLibrary)
            {
                ViewBag.error = "Bu kitap zaten bir öğrencide.";
            }
            ViewBag.book= _book;
            return View();
        }

        [HttpPost]
        public IActionResult RegisteredStudent(int bookId, string email, DateTime date)
        {
            var student = _studentService.GetStudentByEmail(email);

            //Girilen maile sahip bir öğrenci bulunamaması durumunda bununla ilgili hatanın geri dönüşü yapılır.
            if (student == null)
            {
                TempData["error"] = "Öğrenci bulunamadı.";
                return RedirectToAction("Index", new {id=bookId});
            }

            //Girilen tarih o anki tarihle aynı ya da önce olamaz. Bunun kontrolü sağlanır.
            if (date<DateTime.Now.ToLocalTime())
            {
                TempData["error"] = "Lütfen geçerli bir tarih giriniz.";
                return RedirectToAction("Index", new { id = bookId });
            }

            //Server tabanlı oluşabailecek hatanın geri dönüşü yapılır.
            if (!_bookService.OduncVer(bookId, student.Id, date))
            {
                TempData["error"] = "Bir hata oluştu.";
                return RedirectToAction("Index", new { id = bookId });
            }

            TempData["success"] = "İşlem başarılı.";

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult NewStudent(int bookId, Student student, DateTime date)
        {
            //Aynı maile sahip öğrencinin bulunması durumunda bununla ilgili hatanın geri dönüşü yapılır.
            if (!_studentService.MailControl(student))
            {
                TempData["newstudenterror"] = "Bu mail adresine sahip bir öğrenci zaten var.";
                return RedirectToAction("Index", new { id = bookId });
            }

            //Girilen tarih o anki tarihle aynı ya da önce olamaz. Bunun kontrolü sağlanır.
            if (date < DateTime.Now.ToLocalTime())
            {
                TempData["newstudenterror"] = "Lütfen geçerli bir tarih giriniz.";
                return RedirectToAction("Index", new { id = bookId });
            }

            //Server tabanlı oluşabailecek hatanın geri dönüşü yapılır.
            if (!_bookService.YeniOgrenciyeOduncVer(bookId, student, date))
            {
                TempData["newstudenterror"] = "Bir hata oluştu.";
                return RedirectToAction("Index", new { id = bookId });
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GeriAl(int id)
        {
            if (!_bookService.GeriAl(id))
            {
                TempData["error"] = "Bir hata oluştu.";
            }
            else
            {
                TempData["success"] = "İşlem başarılı.";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
