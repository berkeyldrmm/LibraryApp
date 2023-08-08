using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class StudentDal : GenericRepository<Student>, IStudentDal
    {
        public StudentDal(LibraryDbContext context) : base(context)
        {
        }

        //Kayıtlı öğrenciye ödünç verme işlemi, öğrenciyi mail yoluyla tanıyarak yapılır.
        //Bu amaca binaen ilgili maile sahip öğrenci bu metotla bulunur.
        public Student GetStudentByEmail(string email)
        {
            return _context.Students.SingleOrDefault(s=>s.Email==email);
        }

        //Her öğrencinin maili kendine özgü (unique) olmalıdır.
        //Bu metotla mail adresine sahip başka bir kullanıcı olup olmadığı kontrol edilir.
        public bool MailControl(Student student)
        {
            Student std = _context.Students.FirstOrDefault(s=>s.Email== student.Email);
            if(std!=null)
            {
                return false;
            }
            return true;

        }
    }
}
