using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class RoleViewModel
    {
        [Display(Name = "نقش سیستمی")]
        [Required (ErrorMessage ="")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Display(Name = "نقش")]
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
    }
}
