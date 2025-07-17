using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.DataAccessLayer.Entites
{
    public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "نام ")]
        [MaxLength(100)]
        public string Name { get; set; } 
        
        
        [Display(Name = "توضیحات")]
        public string Desc { get; set; }    
        
        [Display(Name = "درباره ما")]
        public string About { get; set; }   
        
        
        [Display(Name = "شرایط و قوانین")]
        public string Terms { get; set; }      
        
        [Display(Name = "شماره تماس")]
        [MaxLength(40)]
        public string Tel { get; set; }   
        
        [Display(Name = "شماره فکس")]
        [MaxLength(40)]
        public string Fax { get; set; }    
        
        [Display(Name = "اب و هوا در قیمت")]
        public bool IsWeatherPrice { get; set; }      
        
        [Display(Name = "مسافت در قیمت")]
        public bool IsDistance { get; set; }


    }
}
