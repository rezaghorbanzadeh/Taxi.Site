using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class AboutSettingViewModel
    {
        [MaxLength(40)]
        [Display(Name = "درباره ما")]
        public string About { get; set; }
    }
}
