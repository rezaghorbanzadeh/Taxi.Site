using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DataAccessLayer.Entites
{
    public class UserAddresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid UserID { get; set; }

        [Display(Name = "نام ")]
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }    
        
        [Display(Name = "طول جغرافیایی ")]
        [Required]
        [MaxLength(40)]
        public string Lat { get; set; }    
        
        [Display(Name = "عرض جغرافیایی ")]
        [Required]
        [MaxLength(40)]
        public string Lng { get; set; }    
        
        [Display(Name = "ادرس ")]
        [Required]
        [MaxLength(40)]
        public string Desc { get; set; }

        public virtual User User { get; set; }
    }
}
