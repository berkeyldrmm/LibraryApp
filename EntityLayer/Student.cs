using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Student
    {
        public Student()
        {
            Book=new HashSet<Book>();
        }
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
