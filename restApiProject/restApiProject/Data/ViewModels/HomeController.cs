using Microsoft.AspNetCore.Mvc;

namespace restApiProject.Data.ViewModels
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
