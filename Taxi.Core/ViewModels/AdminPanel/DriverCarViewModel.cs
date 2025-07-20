using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.AdminPanel
{
    public class DriverCarViewModel
    {
        public Guid? CarId { get; set; } 
        public Guid? CarColorId { get; set; } 


        [Display(Name = "شماره پلاک ")]
        public string CarCode { get; set; }


    }
}
