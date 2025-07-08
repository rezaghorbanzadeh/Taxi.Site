using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Taxi.Core.Generators
{
    public static class CodeGenerator
    {
        //generate code for login and register 6 digit
        public static string GetActiveCode()
        {
            Random random = new Random();
            return random.Next(100000,990000).ToString();
        }

        //generate Guid for key 
        public static Guid GetId() 
        { 
            return Guid.NewGuid();
        }

        //generate name for file(upload file)
        public static string GetFileName()
        { 
            return Guid.NewGuid().ToString().Replace("-","");
        }

        //generate code for order code
        public static string GetOrderCode()
        {
            Random random = new Random();
            return random.Next(10000000, 99000000).ToString();
        }
    }
}
