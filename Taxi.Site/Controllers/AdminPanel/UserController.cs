using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.ViewModels.AdminPanel;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class UserController : Controller
    {
        private IAdmin _admin;

        public UserController(IAdmin admin)
        {
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetUsers();
            return View(result);
        }

        public async Task <IActionResult> Create()
        {
            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddUser(viewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title", viewModel.RoleId);

            return View(viewModel);
        }
        
        public async Task <IActionResult> Edite(Guid id)
        {
            User user = await _admin.GetUserById(id);

            UserViewModel viewModel = new UserViewModel()
            {
                RoleId = user.Id,
                IsActive = user.IsActive,
                UserName = user.UserName,
            };
            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title",user.RoleId);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edite(UserViewModel viewModel,Guid id)
        {
            if (ModelState.IsValid)
            {
                _admin.UpdateUser(viewModel,id);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title", viewModel.RoleId);

            return View(viewModel);
        }     
        
        
        public async Task<IActionResult> DriverProp(Guid id)
        { 
            var result = await _admin.GetDriver(id);

            DriverPropViewModel viewModel = new DriverPropViewModel()
            {
                Address = result.Address,
                AvatarName = result.Avatar,
                NatinalCode = result.NationalCode,
                Tel = result.Tel,
            };
            ViewBag.IsError = false;
            ViewBag.IsSuccess = false;

            return View(viewModel);
        } 
        [HttpPost]
        public async Task<IActionResult> DriverProp(Guid id, DriverPropViewModel viewModel)
        {

            bool status = false;

            if (ModelState.IsValid)
            {
                status = _admin.UpdateDriverProp(id, viewModel);
            }
            if (status)
            {
                ViewBag.IsError = false;
                ViewBag.IsSuccess = true;

            }
            else
            {
                ViewBag.IsError = true;
                ViewBag.IsSuccess = false;
            }



                var result = await _admin.GetDriver(id);

            DriverPropViewModel model = new DriverPropViewModel()
            {
                Address = result.Address,
                AvatarName = result.Avatar,
                NatinalCode = result.NationalCode,
                Tel = result.Tel,
            };
            if (ModelState.IsValid)
            {
               
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

    }
     
}
