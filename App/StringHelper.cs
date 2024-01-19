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
            if (part1 == null)
            {
                throw new ArgumentNullException(nameof(part1));
            }
            if (part1 == string.Empty && part2 == string.Empty)
            {
                return string.Empty;
            }
            if (part2 == null)
            {
                return part1;
            }
            if (part1 == string.Empty && part2 != string.Empty)
            {
                throw new ArgumentException("Перший аргумент порожній, а другий непорожній.", nameof(part1));
            }

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
            // 2.2 ХР - мінімальна складність для одного тесту
            // return "1 000";
            // 4. Для більшої кількості тестів - складаємо алгоритм.
            /* 
             // для цілих чисел - можна використати арифметичні операції
            StringBuilder sb = new();
            while (number != 0)  // 123456
            {
                long d = number % 1000;
                number /= 1000;
                if( number != 0 )
                {
                    sb.Insert(0, Math.Abs(d).ToString("000") );
                    sb.Insert(0, ' ');
                }
                else
                {
                    sb.Insert(0, d);
                }
            } 
            return sb.ToString(); 
            */
            // 6. Перехід на дробові числа ускладнює арифметику
            // переходимо на рядкові операції
            String numStr = number == Math.Round(number)
                ? number.ToString()
                : number.ToString("F10", CultureInfo.InvariantCulture).TrimEnd('0');
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
                for (i = dotPosition + 1; i < numStr.Length; i += 3)
                {
                    String fragment = (i + 3 < numStr.Length)
                        ? numStr[i..(i + 3)]
                        : numStr[i..];
                    if (i == dotPosition + 1)
                    {
                        list[^1] += $".{fragment}";
                    }
                    else
                    {
                        list.Add(fragment);
                    }
                }
            }
            return String.Join(" ", list);
        }
    }
}
