using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.ViewModels.AdminPanel;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class AdminPanelController : Controller
    {
        private IAdmin _admin;

        public AdminPanelController(IAdmin admin)
        {
            _admin = admin;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SiteSetting() {
            Setting setting = await _admin.GetSetting();

            SiteSettingViewModel viewModel = new SiteSettingViewModel()
            {
                Desc = setting.Desc,
                Name = setting.Name,    
                Fax = setting.Fax,  
                Tel = setting.Tel,
            };

            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SiteSetting(SiteSettingViewModel viewModel) {

            if (ModelState.IsValid) { 
            
                bool result = _admin.UpdateSiteSetting(viewModel);
                ViewBag.IsSuccess = result;
            }
          
            return View(viewModel);
        }  
        
        
        public async Task<IActionResult> PriceSetting() {
            Setting setting = await _admin.GetSetting();

            PriceSettingViewModel viewModel = new PriceSettingViewModel()
            {
                    IsDistance = setting.IsDistance,    
                    IsWeatherPrice = setting.IsWeatherPrice,    
            };

            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PriceSetting(PriceSettingViewModel viewModel) {

            if (ModelState.IsValid) { 
            
                bool result = _admin.UpdatePriceSetting(viewModel);
                ViewBag.IsSuccess = result;
            }
            return View(viewModel);
        }   
        
        
        public async Task<IActionResult> AboutSetting() {
            Setting setting = await _admin.GetSetting();

            AboutSettingViewModel viewModel = new AboutSettingViewModel()
            {
                    About = setting.About,    
            };

            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AboutSetting(AboutSettingViewModel viewModel) {

            if (ModelState.IsValid) { 
            
                bool result = _admin.UpdateAboutSetting(viewModel);
                ViewBag.IsSuccess = result;
            }
            return View(viewModel);
        } 
        
        
        
        public async Task<IActionResult> TermSetting() {
            Setting setting = await _admin.GetSetting();

            TermSettingViewModel viewModel = new TermSettingViewModel()
            {
                    Terms = setting.Terms,    
            };

            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult TermSetting(TermSettingViewModel viewModel) {

            if (ModelState.IsValid) { 
            
                bool result = _admin.UpdateTermSetting(viewModel);
                ViewBag.IsSuccess = result;
            }
            return View(viewModel);
        }
    }
}
