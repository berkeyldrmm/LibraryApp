using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class BookDal : GenericRepository<Book>, IBookDal
    {
        public BookDal(LibraryDbContext context) : base(context)
        {
        }
        //Veritabanında kayıtlı olan öğrenciye kitap ödünç verme işlemi
        //Burada foregn key üzerinden kitap ve öğrenci arasında ilişki kurulur.
        public bool OduncVer(Book book, int id, DateTime dateTime)
        {
            
            book.StudentId = id;
            book.IsInLibrary = false;
            book.Deadline = dateTime;
            EntityEntry<Book> entityEntry = _context.Update(book);
            if(entityEntry.State == EntityState.Modified)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        //Veritabanında kayıtlı olmayan öğrenciye kitap ödünç verme işlemi
        //Burada navigation property üzerinden kitap ve öğrenci arasında ilişki kurulur
        //ve böylece öğrencinin de ilgili tabloya kayıt edilmesi sağlanır.
        public bool YeniOgrenciyeOduncVer(Book book, Student student, DateTime dateTime)
        {
            book.Student = student;
            book.Deadline = dateTime;
            book.IsInLibrary = false;
            EntityEntry<Book> entityEntry = _context.Update(book);
            if (entityEntry.State == EntityState.Modified)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        //Kitabın veritabanında bulunup bulunmadığı kontrol edilir.
        //Kitap isimleri benzeyebileceği için isminden sonra yazarı da kontrol edilir.
        public async Task<bool> BookExistControl(Book book)
        {
            Book b = await _context.Books.SingleOrDefaultAsync(b => b.BookName == book.BookName);
            if (b != null && b.BookAuthor==book.BookAuthor)
            {
                return false;
            }
            return true;
        }

        public bool GeriAl(int id)
        {
            Book book=ReadOne(id);
            book.StudentId = null;
            book.Student = null;
            book.Deadline = null;
            book.IsInLibrary = true;
            EntityEntry<Book> entityEntry = _context.Update(book);
            if (entityEntry.State == EntityState.Modified)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
