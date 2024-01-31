using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var friends = new Dictionary<string, (int, int)>();
            var tmpStr = Console.ReadLine().Split(" ");
            int n = Convert.ToInt32(tmpStr[0]);
            int m = Convert.ToInt32(tmpStr[1]);
            int gw = Convert.ToInt32(tmpStr[2]);
            var a = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var b = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                friends.Add($"{i + 1}", (a[i], b[i]));
            }
            for (int i = 0; i < m; i++)
            {
                var pair = Console.ReadLine().Split(" ");
                var firstFriends = friends.Where(x => x.Key.Contains($"{pair[0]}")).Select(x => x.Key).ToArray();
                var secondFriends = friends.Where(x => x.Key.Contains($"{pair[1]}")).Select(x => x.Key).ToArray();

                var mergedCompanyKey = firstFriends[0] + secondFriends[0];
                var mergedCompanyValue = (friends[firstFriends[0]].Item1 + friends[secondFriends[0]].Item1, friends[firstFriends[0]].Item2 + friends[secondFriends[0]].Item2);

                friends.Remove(firstFriends[0]);
                friends.Remove(secondFriends[0]);
                friends.Add(mergedCompanyKey, mergedCompanyValue);
            }
            var param = friends.Values.ToArray();
            int maxIntr = 0;
            Function(param.Length, 0, 0, param, ref maxIntr, gw);
            Console.WriteLine(maxIntr);
        }

        public static void Function(int n, int sumIntr, int sumProv, (int, int)[] param, ref int maxIntr, int gw)
        {
            if (n != 0)
            {
                int sumI = sumIntr + param[n - 1].Item1;
                int sumP = sumProv + param[n - 1].Item2;
                if (sumP <= gw && sumI > maxIntr)
                    maxIntr = sumI;

                Function(n - 1, sumI, sumP, param, ref maxIntr, gw);
                Function(n - 1, sumIntr, sumProv, param, ref maxIntr, gw);
            }
        }
    }
}
