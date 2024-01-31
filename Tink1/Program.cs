using System.Text.RegularExpressions;
using System;

namespace Tink1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string codePattern = @"code\d+";

            Console.WriteLine(Regex.Replace(Console.ReadLine(), codePattern, "???"));
        }
    }
}
