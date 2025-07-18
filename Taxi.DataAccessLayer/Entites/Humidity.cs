using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DataAccessLayer.Entites
{
    public class Humidity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام ")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        

        [Display(Name = " از میزان")]
        public int Start { get; set; }
        
        [Display(Name = " تا میزان")]
        public int End { get; set; }   
        
        
        [Display(Name = " درصد")]
        public float Precent { get; set; }

       
    }
}
