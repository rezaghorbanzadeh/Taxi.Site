using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.ViewModels.AdminPanel;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class PriceTypeController : Controller
    {
        private IAdmin _admin;

        public PriceTypeController(IAdmin admin)
        {
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetPriceType();
            return View(result);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(PriceTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddPriceType(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Edite(Guid id)
        {
            var result = await _admin.GetPriceTypeById(id);
            PriceTypeViewModel viewModel = new PriceTypeViewModel()
            {
                Name = result.Name,
                Price = result.Price,
                Start = result.Start,
                End = result.End,
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edite(Guid id, PriceTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdatePriceType(id, viewModel);
                if(result == true)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id, PriceTypeViewModel viewModel)
        {
            var result = _admin.DeletePriceType(id);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}
