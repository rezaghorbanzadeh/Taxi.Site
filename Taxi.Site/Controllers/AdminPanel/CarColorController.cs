using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.ViewModels.AdminPanel;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class CarColorController : Controller
    {
        private IAdmin _admin;

        public CarColorController(IAdmin admin)
        {
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetColor();
            return View(result);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CarColorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddColor(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Edite(Guid id)
        {
            var result = await _admin.GetColorId(id);
            CarColorViewModel viewModel = new CarColorViewModel()
            {
                Name = result.Name
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edite(Guid id, CarColorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateColor(id, viewModel);
                if(result == true)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id, CarColorViewModel viewModel)
        {
            var result = _admin.DeleteColor(id);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}
