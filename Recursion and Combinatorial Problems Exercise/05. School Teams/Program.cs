using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._School_Teams
{
    public class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var girlsComb = new string[3];
            var girlsCombinations = new List<string[]>();
            
            Combinations(0, 0, girls, girlsComb, girlsCombinations);

            var boys = Console.ReadLine().Split(", ");
            var boysComb = new string[2];
            var boysCombinations = new List<string[]>();

            Combinations(0, 0, boys, boysComb, boysCombinations);

            PrintFinalCombs(girlsCombinations, boysCombinations);

        }

        private static void PrintFinalCombs(List<string[]> girlsCombinations, List<string[]> boysCombinations)
        {
            foreach (var girlComb in girlsCombinations)
            {
                foreach (var boyComb in boysCombinations)
                {
                    Console.WriteLine($"{string.Join(", ", girlComb)}, {string.Join(", ", boyComb)}");
                }
            }
        }

        private static void Combinations(int idx, int start, string[] elements, string[] combination, List<string[]> results)
        {
            if (idx >= combination.Length )
            {
                results.Add(combination.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combination[idx] = elements[i];
                Combinations(idx + 1, i + 1, elements, combination, results);
            }
        }
    }
}
