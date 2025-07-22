using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.ViewModels.Panel
{
    public class FactorViewModel
    {

        [Display(Name = "تاریخ تولد")]
        public long Wallet { get; set; }
    }
}
