using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class DriverPropViewModel
    {
        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "")]
        [Phone]
        [MaxLength(11)]
        public string NatinalCode { get; set; }

        [Display(Name = "شماره ثابت")]
        [MaxLength(30)]
        public string Tel { get; set; }
        
        [Display(Name = "ادرس")]

        public string Address { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile Avatar { get; set; }
        public string AvatarName { get; set; }
    }
}
