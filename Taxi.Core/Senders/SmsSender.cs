using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kavenegar;

namespace Taxi.Core.Senders
{
    public static class SmsSender
    {

        public static void VeryFySend(string toUser, string template, string token)
        {

            var api = new KavenegarApi("Your api kavengar");

            var StrTo = toUser;
            var strTamplate = template;
            var strToken = token;

            api.VerifyLookup(StrTo, strToken, strTamplate);
        }
    }

}
