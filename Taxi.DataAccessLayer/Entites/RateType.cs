using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DataAccessLayer.Entites
{
    public class RateType
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "گزینه امتیاز")]
        [MaxLength(40)]
        public string Name { get; set; }  
        
        [Display(Name = "مثبت")]

        public bool Ok { get; set; }  
        
        
        [Display(Name = "ترتیب نمایش")]

        public int ViewOrder { get; set; }



    }
}
