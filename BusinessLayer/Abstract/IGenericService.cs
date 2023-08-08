using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    //Her entity'nin kullanacağı servis metotları burada toplanmış, tipine göre ilgili servisin abstract'ına (interface) miras edilecektir.
    public interface IGenericService<T> where T : class
    {
        Task<bool> AddEntity(T entity);
        IEnumerable<T> ReadAll();
        T ReadOne(int id);
    }
}
