using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class SiteSettingViewModel
    {
        [Display(Name = "نام رنگ")]
        [Required(ErrorMessage ="نام ماشین  مبایل الزامی است")]
        [MaxLength(100,ErrorMessage ="نام رنگ نمیتواند بیشتر از 100 کاراکتر باشد")]
        public string Name { get; set; }


        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Desc { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "نام ماشین  مبایل الزامی است")]
        [MaxLength(40)]
        public string Tel { get; set; }

        [Display(Name = "شماره فکس")]
        [MaxLength(40)]
        public string Fax { get; set; }

    }
}
