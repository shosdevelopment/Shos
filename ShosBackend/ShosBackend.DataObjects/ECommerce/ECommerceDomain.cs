using ShosBackend.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.DataObjects.ECommerce
{
    public static class ECommerceDomain
    {
        public static string GetEndPoint(CountryCode countryCode)
        {
            switch (countryCode)
            {
                case CountryCode.BR:
                    return "br";
                case CountryCode.CN:
                    return "cn";
                case CountryCode.CA:
                    return "ca";
                case CountryCode.DE:
                    return "de";
                case CountryCode.ES:
                    return "es";
                case CountryCode.FR:
                    return "fr";
                case CountryCode.IN:
                    return "in";
                case CountryCode.IT:
                    return "it";
                case CountryCode.JP:
                    return "co.jp";
                case CountryCode.MX:
                    return "com.mx";
                case CountryCode.UK:
                    return "co.uk";
                case CountryCode.US:
                    return "com";
                case CountryCode.AU:
                    return "com.au";
                default:
                    return "com";

            }
        }
    }
}