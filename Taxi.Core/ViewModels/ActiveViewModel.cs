using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Core.ViewModels
{
    public class ActiveViewModel
    {
        [Display(Name = "کد فعال سازی ")]
        [Required(ErrorMessage = "کد فعال سازی  6 رقمی معتبر وارد کنید ")]
        [MaxLength(6, ErrorMessage = "کد فعال سازی  6 رقمی معتبر وارد کنید")]
        [MinLength(6, ErrorMessage = "کد فعال سازی  6 رقمی معتبر وارد کنید")]
        [Phone(ErrorMessage = "شماره مبایل معتبر وارد کنید")]
        public string Code { get; set; }      
        
        [Display(Name = "username")]
        public string Username { get; set; }
    }
}
