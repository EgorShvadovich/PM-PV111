using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class StringHelper
    {
        public String Ellipsis(String input,int maxLength = 80)
        {
            return $"{input[0..maxLength]}...";
        }
        public static string UrlCombine(string part1, string part2)
        {
            if (part1.EndsWith("/"))
            {
                part1 = part1.Substring(0, part1.Length - 1);
            }
            if (part2.StartsWith("/"))
            {
                part2 = part2.Substring(1);
            }
            return $"{part1}/{part2}";
        }
    }
}
