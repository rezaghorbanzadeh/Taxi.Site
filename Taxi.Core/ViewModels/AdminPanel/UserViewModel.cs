using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class UserViewModel
    {
        [Display(Name = "انتخاب نقش")]
        public Guid RoleId { get; set; }
        [Display(Name = "شماره موبایل")]
        [Required (ErrorMessage ="")]
        [MaxLength(11)]
        [MinLength(11)]
        public string UserName { get; set; }

        [Display(Name = "فعال/غیر فعال")]

        public bool IsActive { get; set; }
    }
}
