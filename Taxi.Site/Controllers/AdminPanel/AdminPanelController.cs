using Microsoft.AspNetCore.Mvc;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
