using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHR.Helpers
{
    public static class StringExtension
    {
        public static string SubstringInside(this string str, string mark1, string mark2)
        {
            string result = string.Empty;
            int i1 = str.IndexOf(mark1, 0);
            if (i1 < 0) return result;
            i1 += mark1.Length;
            int i2 = str.IndexOf(mark2, i1);
            if (i2 < 0) return result;
            result = str.Substring(i1, i2-i1);
            return result;
        }
    }
}
