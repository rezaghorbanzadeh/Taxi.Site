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
    public class DriverImgViewModel
    {
        [Display(Name = "تصویر گواهینامه")]
        public IFormFile Img { get; set; }
        public string ImgName { get; set; }

        [Display(Name = "تایید")]

        public bool IsConfirm { get; set; }

    }
}
