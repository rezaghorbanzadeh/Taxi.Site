using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.ViewModels.AdminPanel;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class RateTypeController : Controller
    {
        private IAdmin _admin;

        public RateTypeController(IAdmin admin)
        {
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetRateType();
            return View(result);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(RateTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddRateType(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Edite(Guid id)
        {
            var result = await _admin.GetRateTypeById(id);
            RateTypeViewModel viewModel = new RateTypeViewModel()
            {
                Name = result.Name
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edite(Guid id, RateTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateRateType(id, viewModel);
                if(result == true)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id, RateTypeViewModel viewModel)
        {
            var result = _admin.DeleteRateType(id);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}
