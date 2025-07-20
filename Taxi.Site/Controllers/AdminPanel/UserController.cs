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
            UserDetail detail = await _admin.GetUserDetail(id);

            UserEditViewModel viewModel = new UserEditViewModel()
            {
                RoleId = user.Id,
                IsActive = user.IsActive,
                UserName = user.UserName,
                BirthDate = detail.BirthDate,
                FullName = detail.FullName, 
            };
            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title",user.RoleId);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edite(UserEditViewModel viewModel,Guid id)
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


            return View(viewModel);
        } 
        [HttpPost]
        public async Task<IActionResult> DriverProp(Guid id, DriverPropViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               _admin.UpdateDriverProp(id, viewModel);
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

        public async Task<IActionResult> DriverCertificate(Guid id)
        {
            var driver = await _admin.GetDriver(id);

            DriverImgViewModel viewModel = new DriverImgViewModel()
            {
                ImgName = driver.CarImg,
                IsConfirm = driver.IsConfirm,
            };


            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DriverCertificate(Guid id, DriverImgViewModel viewModel)
        {
            var driver = await _admin.GetDriver(id);

            if (ModelState.IsValid) { 
            _admin.UpdateDriverCertificate(id, viewModel);
            
            }
            DriverImgViewModel model = new DriverImgViewModel()
            {
                ImgName = driver.CarImg,
                IsConfirm = driver.IsConfirm,
            };
            ViewBag.IsError = false;
            ViewBag.IsSuccess = false;
            if (ModelState.IsValid)
            {

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> DriverCar(Guid id)
        {
            var driver  = await _admin.GetDriver(id);

            DriverCarViewModel viewModel = new DriverCarViewModel()
            {
                CarCode = driver.CarCode,
                CarId = driver.CaraId,
                CarColorId = driver.CarColorId,
            };
            if (driver.CaraId == null)
            {
                ViewBag.CarId = new SelectList(await _admin.GetCars(), "Id", "Name");

            }
            else
            {
                ViewBag.CarId = new SelectList(await _admin.GetCars(), "Id", "Name",viewModel.CarId);
            }    
            if (driver.CarColorId == null)
            {
                ViewBag.CarColorId = new SelectList(await _admin.GetColor(), "Id", "Name");

            }
            else
            {
                ViewBag.CarColorId = new SelectList(await _admin.GetColor(), "Id", "Name", viewModel.CarColorId);
            }
               
            
            ViewBag.IsSuccess = false ;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DriverCar(Guid id ,DriverCarViewModel viewModel)
        {

            if (ModelState.IsValid) { 
             _admin.UpdateDriverCar(id, viewModel);
            
            }

            ViewBag.CarId = new SelectList(await _admin.GetCars(),"Id","Name",viewModel.CarId);
            ViewBag.CarColorId = new SelectList(await _admin.GetColor(),"Id","Name",viewModel.CarColorId);
            
            ViewBag.IsSuccess = false ;
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));

            }

            return View(viewModel);
        }
    }



      

    }
