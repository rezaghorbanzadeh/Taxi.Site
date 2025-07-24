using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class AdminDiscountsViewModel
    {
        [Display(Name = " عنوان")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [Display(Name = "کد تخفیف")]
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Display(Name = "مبلغ تخفیف")]
        public long Price { get; set; }

        [Display(Name = "درصد تخفیف")]
        public int Percent { get; set; }

        [Display(Name = "سایر توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Desc { get; set; }

        [Display(Name = "تاریح شروع")]
        [MaxLength(10)]
        public string Start { get; set; }

        [Display(Name = "تاریح پایان")]
        [MaxLength(10)]
        public string Expire { get; set; }
    }
}
