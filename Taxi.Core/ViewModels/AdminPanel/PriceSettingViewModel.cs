using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class PriceSettingViewModel
    {
        [Display(Name = "اب و هوا در قیمت")]
        public bool IsWeatherPrice { get; set; }

        [Display(Name = "مسافت در قیمت")]
        public bool IsDistance { get; set; }

    }
}
