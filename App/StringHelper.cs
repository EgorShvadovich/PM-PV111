using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class StringHelper
    {
        public String Ellipsis(String input,int maxLength = 80)
        {
            if(input == null) throw new ArgumentNullException(nameof(input));
            if (maxLength >= input.Length) return input;
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
        
        public String Spacefy(double number)
        {
            String numStr = number.ToString(CultureInfo.InvariantCulture);
            int dotPosition = numStr.IndexOf('.');
            List<String> list = new();
            int i;
            if (dotPosition == -1)  // точки немає
            {
                for (i = numStr.Length; i - 3 >= 0; i -= 3)
                {
                    list.Insert(0, numStr[(i - 3)..i]);
                }
                if (i > 0)
                {
                    list.Insert(0, numStr[..i]);
                }
            }
            else
            {
                for (i = dotPosition; i - 3 >= 0; i -= 3)
                {
                    list.Insert(0, numStr[(i - 3)..i]);
                }
                if (i > 0)
                {
                    list.Insert(0, numStr[..i]);
                }
                for (i = dotPosition; i + 3 < numStr.Length; i += 3)
                {
                    if (i == dotPosition)
                    {
                        list[^1] += numStr[i..(i + 3)];
                    }
                    else
                    {
                        list.Add(numStr[i..(i + 3)]);
                    }
                }
                if (i < numStr.Length)
                {
                    if (i == dotPosition)
                    {
                        list[^1] += numStr[i..];
                    }
                    else
                        list.Add(numStr[i..]);
                }
            }
            return String.Join(" ", list);

        }
    }
}
