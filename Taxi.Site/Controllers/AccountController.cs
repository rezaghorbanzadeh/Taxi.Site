﻿using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Interfaces;
using Taxi.Core.ViewModels;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Site.Controllers
{
    public class AccountController : Controller
    {
        private IAccounting _accounting;

        public AccountController(IAccounting accounting)
        {
            _accounting = accounting;
        }

        [HttpGet]
        public  IActionResult Register()
        {
            return View();
        }  
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid) { 
                User user  =await _accounting.RegisterUser(viewModel);

                if (user != null) {
                    return RedirectToAction("Active", new { username = user.UserName });

                }

            }
            return View(viewModel );
        }

        [HttpGet]
        public IActionResult Driver()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Driver(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _accounting.RegisterDriver(viewModel);

                if (user != null)
                {
                    return RedirectToAction("Active", new { username = user.UserName });

                }

            }
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Active()
        {

             ViewBag.IsError = false;
            return View("Active");
        }

        [HttpPost]
        public async Task<IActionResult>  Active(ActiveViewModel viewModel)
        {
            if (ModelState.IsValid) { 
               
            User user = await _accounting.ActiveCode(viewModel);
                if (user != null) { 
                ViewBag.IsError = false ;
                    // 
                }
            }
            return View(viewModel);
        }






        
    }
}
