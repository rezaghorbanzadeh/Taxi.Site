﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class MonthTypeViewModel
    {
        [Display(Name = "نام تعرفه")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [Display(Name = " از ")]
        public int Start { get; set; }

        [Display(Name = " تا ")]
        public int End { get; set; }


        [Display(Name = "  نرخ ثابت")]
        public long Precent { get; set; }
    }
}
