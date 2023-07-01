using System;
using System.Collections.Generic;

namespace _02._Chainalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var transactions = new List<Tuple<string, string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] transaction = Console.ReadLine().Split(' ');
                string sender = transaction[0];
                string receiver = transaction[1];
                int amount = int.Parse(transaction[2]);
                transactions.Add(new Tuple<string, string, int>(sender, receiver, amount));
            }

            int groupCount = CountGroups(transactions);
            Console.WriteLine(groupCount);
        }

        static int CountGroups(List<Tuple<string, string, int>> transactions)
        {
            var groups = new Dictionary<string, HashSet<string>>();

            foreach (var transaction in transactions)
            {
                string sender = transaction.Item1;
                string receiver = transaction.Item2;

                if (!groups.ContainsKey(sender))
                    groups.Add(sender, new HashSet<string>());

                if (!groups.ContainsKey(receiver))
                    groups.Add(receiver, new HashSet<string>());

                groups[sender].Add(receiver);
                groups[receiver].Add(sender);

                foreach (var group in groups.Values)
                {
                    if (group.Contains(sender))
                    {
                        foreach (string address in group)
                        {
                            groups[address].UnionWith(group);
                        }
                    }
                }
            }

            var visited = new HashSet<string>();
            int groupCount = 0;

            foreach (var group in groups.Values)
            {
                if (groupCount == 0 || !visited.Overlaps(group))
                {
                    groupCount++;
                    visited.UnionWith(group);
                }
            }

            return groupCount;
        }

    }
}
