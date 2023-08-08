using EntityLayer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBookService : IGenericService<Book>
    {
        //Book entity'sine özel metotlar
        public bool OduncVer(int bookId, int id, DateTime dateTime);
        public bool YeniOgrenciyeOduncVer(int bookId, Student student, DateTime dateTime);
        public Task<string> GorselOlustur(IFormFile kitapGorsel);
        public Task<bool> BookExistControl(Book book);
        public bool GeriAl(int id);
    }
}
