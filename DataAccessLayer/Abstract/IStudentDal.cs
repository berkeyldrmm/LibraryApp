using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IStudentDal : IRepository<Student>
    {
        //Student entity'si için özel metotlar
        Student GetStudentByEmail(string email);
        bool MailControl(Student student);
    }
}
