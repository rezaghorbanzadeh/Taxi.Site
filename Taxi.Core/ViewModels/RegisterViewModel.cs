using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "شملره همراه")]
        [Required(ErrorMessage ="فیلد شماره مبایل الزامی است")]
        [MaxLength(11,ErrorMessage ="شماره موبایل نمیتواند کمتر از 11 کاراکتر باشد")]
        [MinLength(11,ErrorMessage = "شماره موبایل نمیتواند بیشتر از 11 کاراکتر باشد")]
        [Phone(ErrorMessage ="شماره مبایل معتبر وارد کنید")]
        public string Username { get; set; }
    }
}
