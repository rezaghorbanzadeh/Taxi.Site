using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DataAccessLayer.Entites
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public Guid? CaraId { get; set; }
        public Guid? CarColorId { get; set; }

        [Display(Name = "کد ملی")]
        [MaxLength(10)]
        public string NationalCode { get; set; }


        [Display(Name = "شمارخ تماس")]
        [MaxLength(30)]
        public string Tel { get; set; }  
        
        [Display(Name = "ادرس")]

        public string Address { get; set; }

        [Display(Name = "پلاک ماشین")]
        [MaxLength(30)]
        public string CarCode  { get; set; }
        [Display(Name = "تصویر گواهینامه")]
        public string CarImg  { get; set; }
        [Display(Name = " تصویر راننده")]
        public string Avatar  { get; set; }
        [Display(Name = "تایید")]
        public bool IsConfirm  { get; set; }

        public virtual User User { get; set; }


        [ForeignKey("CorId")]
        public virtual Car Car { get; set; }  
        
        [ForeignKey("CarColorId")]
        public virtual CarColor CarColor { get; set; }
    }
}
