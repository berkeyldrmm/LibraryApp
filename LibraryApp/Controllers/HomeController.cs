using BusinessLayer.Abstract;
using EntityLayer;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}