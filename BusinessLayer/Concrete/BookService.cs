using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BookService : IBookService
    {
        //Dependency injection
        public IBookDal _bookDal { get; set; }
        public BookService(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        public async Task<bool> AddEntity(Book entity)
        {
            return await _bookDal.Insert(entity);
        }

        public IEnumerable<Book> ReadAll()
        {
            return _bookDal.ReadAll().OrderBy(book=>book.BookName);
        }

        public Book ReadOne(int id)
        {
            return _bookDal.ReadOne(id);
        }

        //Kayıtlı öğrenciye ödünç verme işlemi için Data Access katmanındaki ilgili metodu çağırır.
        public bool OduncVer(int bookId, int id, DateTime dateTime)
        {
            Book book=ReadOne(bookId);
            return _bookDal.OduncVer(book, id, dateTime);
        }

        //Yeni öğrenciye ödünç verme işlemi için Data Access katmanındaki ilgili metodu çağırır.
        public bool YeniOgrenciyeOduncVer(int bookId, Student student, DateTime dateTime)
        {
            Book book = ReadOne(bookId);
            return _bookDal.YeniOgrenciyeOduncVer(book, student, dateTime);
        }

        //Eklenen kitabın görselinin random bir isimde oluşturularak sisteme kaydedilmesi
        //ve bu görselin path'inin oluşturulması
        public async Task<string> GorselOlustur(IFormFile kitapGorsel)
        {
            var extension = Path.GetExtension(kitapGorsel.FileName);
            var randomName = String.Format($"{Guid.NewGuid()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Books", randomName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await kitapGorsel.CopyToAsync(stream);
            }
            return randomName;
        }

        public async Task<bool> BookExistControl(Book book)
        {
            return await _bookDal.BookExistControl(book);
        }

        public bool GeriAl(int id)
        {
            return _bookDal.GeriAl(id);
        }
    }
}
