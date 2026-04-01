using System;
using System.Text.RegularExpressions;

namespace SharpAlert
{
    public static class AprilFools
    {
        public static readonly bool IsAprilFoolsNow = DateTimeOffset.Now.Month == 4 && DateTimeOffset.Now.Day == 1;

        public static string OwOify(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            if (!IsAprilFoolsNow)
            {
                return input;
            }

            double prefixChance = 0.3;
            double suffixChance = 0.4;
            bool yAfterN = true;
            bool repeatYWords = true;
            bool prefixes = true;
            bool suffixes = true;

            Random rand = new();
            string output = input;

            output = output.Replace("r", "w").Replace("l", "w").Replace("R", "W").Replace("L", "W");

            if (yAfterN)
            {
                output = Regex.Replace(output, "n([aeiou])", "ny$1", RegexOptions.IgnoreCase);
            }

            if (repeatYWords)
            {
                output = Regex.Replace(output, @"\b(\w*y)\b", m =>
                {
                    return $"{m.Value} {m.Value}";
                }, RegexOptions.IgnoreCase);
            }

            if (prefixes && rand.NextDouble() < prefixChance)
            {
                string[] pre = { "owo ", "uwu ", ">w< ", "^w^ " };
                output = pre[rand.Next(pre.Length)] + output;
            }

            if (suffixes && rand.NextDouble() < suffixChance)
            {
                string[] suf = { " owo", " uwu", " >w<", " ^w^" };
                output += suf[rand.Next(suf.Length)];
            }

            return output;
        }
    }
}
