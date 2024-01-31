using System;
using System.Collections.Generic;
using System.Linq;

namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool result = true;
            var days = new List<(int, int)>();
            var gifts = new Dictionary<int, int>();
            var n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tmpStr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                days.Add((tmpStr[0] + tmpStr[1], tmpStr[2]));
            }

            days = days.OrderBy(x => x.Item2).ToList();

            var length = days.Count();
            for (int i = 0; i < length; i++)
            {
                while (true)
                {
                    if (gifts.TryAdd(days[i].Item1, days[i].Item2))
                        break;
                    days[i] = (days[i].Item1 + 1, days[i].Item2);
                }
            }

            foreach (var x in gifts)
            {
                if (x.Key > x.Value)
                {
                    result = false;
                    break;
                }
            }

            if (result)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}