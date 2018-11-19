using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.UtilsService.ExtensionMethods
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string value) => value == null || value.Length == 0;
    }
}
