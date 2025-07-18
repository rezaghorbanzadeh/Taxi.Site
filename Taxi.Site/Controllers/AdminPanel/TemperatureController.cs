using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.ViewModels.AdminPanel;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class TemperatureController : Controller
    {
        private IAdmin _admin;

        public TemperatureController(IAdmin admin)
        {
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetTemperature();
            return View(result);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddTemperature(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Edite(Guid id)
        {
            var result = await _admin.GetTemperatureById(id);
            MonthTypeViewModel viewModel = new MonthTypeViewModel()
            {
                Name = result.Name,
                Start = result.Start,
                End = result.End,
                Precent = (long)result.Precent,
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edite(Guid id, MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateTemperature(id, viewModel);
                if(result == true)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id, MonthTypeViewModel viewModel)
        {
            var result = _admin.DeleteTemperature(id);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}
