using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class CarColorViewModel
    {
        [Display(Name = "نام رنگ")]
        [Required(ErrorMessage ="نام ماشین  مبایل الزامی است")]
        [MaxLength(20,ErrorMessage ="نام رنگ نمیتواند بیشتر از 20 کاراکتر باشد")]
        public string Name { get; set; }


        [Display(Name = " کد رنگ")]

        [Required(ErrorMessage = "نام ماشین  مبایل الزامی است")]
        [MaxLength(10, ErrorMessage = "کد رنگ نمیتواند بیشتر از 10 کاراکتر باشد")]
        public string Code { get; set; }

    }
}
