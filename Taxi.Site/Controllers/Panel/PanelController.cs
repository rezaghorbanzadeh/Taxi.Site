using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Interfaces;
using Taxi.Core.ViewModels.Panel;

namespace Taxi.Site.Controllers.Panel
{
    //[Authorize]
    public class PanelController : Controller
    {
        private IPanel _panel;

        public PanelController(IPanel panel)
        {
            _panel = panel;
        }
        public  IActionResult Profile()
        {
            
            return View();
        }
        public async Task<IActionResult> UserProfileUpdate()
        {
            var result =await _panel.GetUserDetail(User.Identity.Name);
            UserDetailProfileViewModel viewModel = new UserDetailProfileViewModel()
            {
                BirthDate = result.BirthDate,
                FullName = result.FullName,
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserProfileUpdate(UserDetailProfileViewModel viewModel)
        {
            var result = await _panel.GetUserDetail(User.Identity.Name);
            bool update = _panel.UpdateUserDetailProfile(result.Id, viewModel);

            if (update) { 
                return View(viewModel);
            
            }
            return View();
        }


        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Payment(FactorViewModel viewModel)
        {
            return View();
        }
    }
}
