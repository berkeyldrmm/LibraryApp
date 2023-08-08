using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    //Interface'in concrete'inin alınması ve metotların içlerinin doldurulması
    //Bu sınıf ilgili bütün entity sınıfları tarafından miras alaınarak kullanılacak.
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public LibraryDbContext _context;
        public GenericRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Insert(T entity)
        {
            EntityEntry<T> entityEntry = await _context.AddAsync(entity);
            if(entityEntry.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }

        public T ReadOne(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
