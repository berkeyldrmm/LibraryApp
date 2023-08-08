using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Generic Repository'nin uygulanmasında abstract sınıfın (interface) oluşturulması
    //ve her entity için ekleme ve okuma (tekli ve hepsi) işlemleri için gerekli metotların imzası.
    public interface IRepository<T>
    {
        Task<bool> Insert(T entity);
        T ReadOne(int id);
        IEnumerable<T> ReadAll();
    }
}
