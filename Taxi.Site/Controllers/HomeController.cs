using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Taxi.Site.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }  
        
        public IActionResult Demo()
        {
            return View();
        }
    }
}
