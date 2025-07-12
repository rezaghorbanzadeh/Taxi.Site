using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Core.Securities
{
    public static class CheckNationalCode
    {
        public static bool CheckCode(string code) {

            var digitString = new[] {"0000000000" ,"1111111111" ,"2222222222","3333333333","4444444444","5555555555"
                ,"6666666666","7777777777","8888888888","9999999999"
            };
            if (digitString.Contains(code)) {
                return false;
            }

            var strCode = code.ToCharArray();

            //221013505

            var num0 = Convert.ToInt32(strCode[0].ToString())*10;
            var num9 = Convert.ToInt32(strCode[1].ToString())*9;
            var num8 = Convert.ToInt32(strCode[2].ToString())*8;
            var num7 = Convert.ToInt32(strCode[3].ToString())*7;
            var num6 = Convert.ToInt32(strCode[4].ToString())*6;
            var num5 = Convert.ToInt32(strCode[5].ToString())*5;
            var num4 = Convert.ToInt32(strCode[6].ToString())*4;
            var num3 = Convert.ToInt32(strCode[7].ToString())*3;
            var num2 = Convert.ToInt32(strCode[8].ToString())*2;

            var a = Convert.ToInt32(strCode[9].ToString());

            var sum = num0 + num9 + num8 + num7 + num6+ num5+ num4+ num3+num2;

            var remaining = sum % 11; 


            return (((remaining < 2) && (a == remaining)) || ((remaining>= 2) && (11 - remaining) == a));


        }
    }
}
