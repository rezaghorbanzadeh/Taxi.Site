using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.Panel
{
    public class UserAddressViewModel
    {

        [Display(Name = "نام")]
        [Required]
        public string Title { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Desc { get; set; }
    }
}
