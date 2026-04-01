using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment56
{
    internal class Program
    {
        private static bool IsAllDigit(string str)
        {
            foreach(char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private static (bool, string) MaskCreditCard(string input)
        {
            string[] parts = input.Split(new string[] {"is"}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                return (false, "");
            }
            string[] segments = parts[1].Trim().Split('-');
            if (segments.Length != 4)
            {
                return (false, "");
            }
            foreach(string segment in segments)
            {
                if (!IsAllDigit(segment) || segment.Length != 4)
                {
                    return (false, "");
                }
            }
            for (int i = 0; i < 3; ++i)
            {
                char[] segment = segments[i].ToCharArray();
                for (int j = 0; j < 4; ++j)
                {
                    segment[j] = 'X';
                }
                segments[i] = new string(segment);
            }
            return (true, parts[0].Trim() + " is " + string.Join("-", segments));
        }

        private static (bool, string) MaskSocialSecurity(string input)
        {
            string[] parts = input.Split(new string[] { "is" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                return (false, "");
            }
            string[] segments = parts[1].Trim().Split('-');
            if (segments.Length != 3)
            {
                return (false, "");
            }
            if (segments[0].Length != 3 || segments[1].Length != 2 || segments[2].Length != 4)
            {
                return (false, "");
            }
            foreach (string segment in segments)
            {
                if (!IsAllDigit(segment))
                {
                    return (false, "");
                }
            }
            for (int i = 0; i < 3; ++i)
            {
                if (i == 1)
                {
                    continue;
                }
                char[] segment = segments[i].ToCharArray();
                for (int j = 0; j < segment.Length; ++j)
                {
                    segment[j] = 'X';
                }
                segments[i] = new string(segment);
            }
            return (true, parts[0].Trim() + " is " + string.Join("-", segments));
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] strings = input.Split(new string[] { "and" }, StringSplitOptions.RemoveEmptyEntries);
            bool valid = true;
            string result1 = "", result2 = "";
            for (int i = 0; i < strings.Length; ++i)
            {
                if (strings[i].Contains("credit card"))
                {
                    (valid, result1) = MaskCreditCard(strings[i].Trim());
                    if (!valid)
                    {
                        break;
                    }
                } else if (strings[i].Contains("social security"))
                {
                    (valid, result2) = MaskSocialSecurity(strings[i].Trim());
                    if (!valid)
                    {
                        break;
                    }
                }
            }
            if (valid)
            {
                string output;
                if (strings.Length == 2)
                {
                    output = result1 + " and " + result2;
                }
                else
                {
                    if (string.IsNullOrEmpty(result1))
                    {
                        output = result2;
                    }
                    else
                    {
                        output = result1;
                    }
                }
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("Invalid input format");
            }
        }
    }
}
