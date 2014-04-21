using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public static class StringExtension
    {
        public static bool IsPositiveNumber(this string str)
        {
            var chars = str.ToCharArray();
            var digits = new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            return !chars.Any(c => !digits.Contains(c));
        }
    }
}
