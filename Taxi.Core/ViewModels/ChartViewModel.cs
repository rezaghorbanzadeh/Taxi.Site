using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Core.ViewModels
{
    public class ChartViewModel
    {

        public string Label { get; set; }     
        public int? Value { get; set; }     
        public string Color { get; set; }     
        

    }
}
