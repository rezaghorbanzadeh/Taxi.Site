﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DataAccessLayer.Entites
{
    public class PriceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام تعرفه")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        

        [Display(Name = " از مسافت")]
        public int Start { get; set; }
        
        [Display(Name = " تا مسافت")]
        public int End { get; set; }   
        
        
        [Display(Name = "  نرخ ثابت")]
        public long Price { get; set; }

       
    }
}
