using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class UserEditViewModel
    {
        [Display(Name = "انتخاب نقش")]
        public Guid RoleId { get; set; }
        [Display(Name = "شماره موبایل")]
        [Required ]
        [MaxLength(11)]
        [MinLength(11)]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100)]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "تاریخ تولد")]
        [MaxLength(10)]
        public string BirthDate { get; set; }
        [Display(Name = "فعال/غیر فعال")]

        public bool IsActive { get; set; }
    }
}
