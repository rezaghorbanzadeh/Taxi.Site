using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class CarViewModel
    {
        [Display(Name = "نام ماشین")]
        [Required(ErrorMessage ="نام ماشین  مبایل الزامی است")]
        [MaxLength(100,ErrorMessage ="نام ماشیبن نمیتواند بیشتر از 100 کاراکتر باشد")]
        public string Name { get; set; }     
        

    }
}
