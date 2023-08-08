using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBookDal : IRepository<Book>
    {
        //Book entity'si için özel metotlar
        public bool OduncVer(Book book, int id, DateTime dateTime);
        public bool YeniOgrenciyeOduncVer(Book book, Student student, DateTime dateTime);
        public Task<bool> BookExistControl(Book book);
        public bool GeriAl(int id);
    }
}
