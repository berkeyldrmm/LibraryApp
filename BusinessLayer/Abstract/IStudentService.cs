using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentService : IGenericService<Student>
    {
        //Student entity'sine özel metotlar
        Student GetStudentByEmail(string email);
        public bool MailControl(Student student);
    }
}
