using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string ImageUrl { get; set; }
        public bool IsInLibrary { get; set; }
    }
}
