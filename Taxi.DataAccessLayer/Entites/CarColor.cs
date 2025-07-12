using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DataAccessLayer.Entites
{
    public class CarColor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام رنگ ")]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }  
        
        
        [Display(Name = " کد رنگ")]
        [MaxLength(10)]
        public string Code { get; set; }

        public virtual ICollection<Driver> Drivers { get;set; }


    }
}
