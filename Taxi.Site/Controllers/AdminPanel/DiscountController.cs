using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.ViewModels.AdminPanel;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class DiscountController : Controller
    {
        private IAdmin _admin;

        public DiscountController(IAdmin admin)
        {
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetDiscounts();
            return View(result);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminDiscountsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddDiscount(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Edite(Guid id)
        {
            var result = await _admin.GetDiscountById(id);
            AdminDiscountsViewModel viewModel = new AdminDiscountsViewModel()
            {
                Name = result.Name
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edite(Guid id, AdminDiscountsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateDiscount(id, viewModel);
                if(result == true)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id, AdminDiscountsViewModel viewModel)
        {
                 _admin.DeleteDiscount(id);
            
                return RedirectToAction(nameof(Index));
         
        }


    }
}
