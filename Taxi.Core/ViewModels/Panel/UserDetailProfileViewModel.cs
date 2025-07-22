using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.Panel
{
    public class UserDetailProfileViewModel
    {
        [Display(Name = "نام خانوادگی")]
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Display(Name = "تاریخ تولد")]

        public string BirthDate { get; set; }
    }
}
