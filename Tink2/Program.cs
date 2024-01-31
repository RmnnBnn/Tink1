using System;
using System.Collections.Generic;
using System.Linq;

namespace ex2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dict = new Dictionary<int, int>();
            var number = Convert.ToInt32(Console.ReadLine());
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < number; i++)
            {
                if (dict.ContainsKey(arr[i]))
                    dict[arr[i]] = dict[arr[i]] + 1;
                else
                    dict.Add(arr[i], 1);
            }

            dict = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine(arr.Distinct().Count());
            foreach (var i in dict)
                Console.Write(i.Value + " ");
        }
    }
}