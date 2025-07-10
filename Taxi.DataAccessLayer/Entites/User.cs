using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DataAccessLayer.Entites
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = " انتخاب نقش")]
        public Guid RoleId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required]
        [MaxLength(11)]

        public string UserName { get; set; }
        [Display(Name = " کد ورورد")]
        [MaxLength(100)]
        public string Password { get; set; }

        [Display(Name = "توکن")]
        
        public string? Token { get; set; }

        [Display(Name = "فعال/غیر فعال")] 
        public bool IsActive { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
