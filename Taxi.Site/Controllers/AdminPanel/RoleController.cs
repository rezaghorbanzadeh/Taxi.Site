using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.ViewModels.AdminPanel;

namespace Taxi.Site.Controllers.AdminPanel
{
    public class RoleController : Controller
    {
        private IAdmin _admin;

        public RoleController(IAdmin admin)
        {
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetRoles();
            return View(result);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddRole(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Edite(Guid id)
        {
            var result = await _admin.GetRoleId(id);
            RoleViewModel viewModel = new RoleViewModel()
            {
                Name = result.Name,
                Title = result.Title
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edite(Guid id, RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateRole(id, viewModel);
                if(result == true)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(viewModel);
        }

        public IActionResult Delete(Guid id,CarViewModel viewModel)
        {
            var result = _admin.DeleteRole(id);
            if (result == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public IActionResult ImportFile()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> ImportFile(IFormFile file)
        //{
        //    using (var stream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(stream);
        //        using (var workbook = new ClosedXML.Excel.XLWorkbook(stream))
        //        {
        //            var worksheet = workbook.Worksheet(1);
        //            var rowCount = worksheet.LastRowUsed().RowNumber();

        //            for (int i = 2; i <= rowCount; i++)
        //            {
        //                var name = worksheet.Cell(i, 1).GetString().Trim();

        //                CarViewModel viewModel = new CarViewModel()
        //                {
        //                    Name = name
        //                };

        //                _admin.AddCar(viewModel);
        //            }
        //        }
        //    }

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
