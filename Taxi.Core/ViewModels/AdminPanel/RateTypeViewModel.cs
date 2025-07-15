using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class RateTypeViewModel
    {
        [Display(Name = "نام رنگ")]
        [Required(ErrorMessage ="نام ماشین  مبایل الزامی است")]
        [MaxLength(40,ErrorMessage ="نام رنگ نمیتواند بیشتر از 20 کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "مثبت")]
        public bool Ok { get; set; }


        [Display(Name = "ترتیب نمایش")]

        public int ViewOrder { get; set; }

    }
}
