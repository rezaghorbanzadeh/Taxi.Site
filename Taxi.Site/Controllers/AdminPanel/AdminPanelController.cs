using System;
using System.Globalization;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Generators;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.ViewModels;
using Taxi.Core.ViewModels.AdminPanel;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class AdminPanelController : Controller
    {
        private IAdmin _admin;
        private PersianCalendar pc = new PersianCalendar ();

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

        public IActionResult WeeklyFactor()
        {
            //0000/00/00
            string strTody = DataTimeGenerator.GetShamsiDate();

            int Ayear = Convert.ToInt32(strTody.Substring(0,4));
            int Amonth = Convert.ToInt32(strTody.Substring(5,2));
            int Aday = Convert.ToInt32(strTody.Substring(8,2));


            string strEndDate = "";
            var carts = new List<ChartViewModel>();

            int intM = 0;

            for (int i = 0; i <=6 ; i++)
            {
                DateTime dtA = pc.ToDateTime(Ayear, Amonth, Aday, 0, 0, 0, 0);

                if(i == 0)
                {
                    dtA = dtA.AddDays(i);
                }
                else
                {
                    intM = -i;
                    dtA = dtA.AddDays(intM);
                }

                strEndDate = pc.GetYear(dtA).ToString("0000") + "/" +
                    pc.GetMonth(dtA).ToString("00") + "/" + pc.GetDayOfMonth(dtA).ToString("00");

                ChartViewModel chartViewModel = new ChartViewModel()
                {
                    Label = strEndDate,
                    Value = _admin.WeeklyFactor(strEndDate),
                    Color = "#333"
                };
                carts.Add(chartViewModel);
            }
            return View(carts);
        }
    }
}
