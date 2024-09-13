using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SimpleObfuscator.ProtectSolution
{
    internal class Randoms
    {
        public static string RandomString()
        {
            return new string((from s in Enumerable.Repeat<string>("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", new Random().Next(10, 100))
                               select s[new Random(Guid.NewGuid().GetHashCode()).Next(s.Length)]).ToArray<char>());
        }

        public static int RandomInt()
        {
            int seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), "\\d+").Value);
            return new Random(seed).Next(0, 99999999);
        }
    }
}
