using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taxi.Core.Generators;
using Taxi.Core.Interfaces;
using Taxi.Core.ViewModels.Panel;
using Taxi.DataAccessLayer.Entites;

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
        
        public async Task<IActionResult> ResultPayment(Guid id)
        {
            var result = await _panel.GetFactor(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(FactorViewModel viewModel)
        {

            UserDetail user = await _panel.GetUserDetail(User.Identity.Name);
            string orderNumber = CodeGenerator.GetOrderCode();

            var checkFactor = _panel.UpdateFactor(user.Id, orderNumber,viewModel.Wallet);

            if (checkFactor == false)
            {
                Factor factor = new Factor()
                {
                    BankName= null,
                    Date = null,
                    Id =CodeGenerator.GetId(),
                    OrderNumber = orderNumber,
                    Price = Convert.ToInt32(viewModel.Wallet),
                    RefNumber =null,
                    Time = null,
                    TraceNumber = null,
                    UserId = user.Id,

                };
                _panel.AddFactor(factor);
            }
            Guid factorId = _panel.GetFactorById(orderNumber);
            var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(viewModel.Wallet));
            var result = payment.PaymentRequest("تراکنش جدید", "https://localhost:40369/Panel/PaymentCallBack?factorId=" + factorId);
            var r = 2;
            if (result.Result.Status == 100) {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);
            
            }
            
            return Redirect("/Panel/ResultPayment"+factorId);
        }

        public async Task<IActionResult> PaymentCallBack(Guid id)
        {
            Factor factor = await _panel.GetFactor(id);
            string authority = HttpContext.Request.Query["Authority"];

            var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(factor.Price));
            var result = payment.Verification(authority).Result;


            if (result.Status == 100)
            {
                _panel.UpdatePayment(factor.Id, DataTimeGenerator.GetShamsiDate(),
                    DataTimeGenerator.GetShamsiTime(), "افزایش اعتبار", "", result.RefId.ToString(), result.RefId.ToString());
            }
            return Redirect("/Panel/ResultPayment" + id);
        }


    }
}
