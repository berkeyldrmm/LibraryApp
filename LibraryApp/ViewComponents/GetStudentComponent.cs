
using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.ViewComponents
{
    //Foreign key yoluyla kitabı ödünç alan öğrencinin ismini render edecek olan component
    public class GetStudentComponent : ViewComponent
    {
        //Dependency injection
        private readonly IStudentService _studentService;

        public GetStudentComponent(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            Student student = _studentService.ReadOne(id);
            return View(student);
        }
    }
}
