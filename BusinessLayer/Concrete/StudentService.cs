using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentService : IStudentService
    {
        //Dependency injection
        public IStudentDal _studentDal { get; set; }

        public StudentService(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public async Task<bool> AddEntity(Student entity)
        {
            return await _studentDal.Insert(entity);
        }

        public IEnumerable<Student> ReadAll()
        {
            return _studentDal.ReadAll();
        }

        public Student ReadOne(int id)
        {
            return _studentDal.ReadOne(id);
        }

        public Student GetStudentByEmail(string email)
        {
            return _studentDal.GetStudentByEmail(email);
        }

        public bool MailControl(Student student)
        {
            return _studentDal.MailControl(student);
        }
    }
}
