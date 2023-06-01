using System;
using System.Linq;

namespace _01._Permutations_without_Repetition
{
    public class Program
    {
        private static char[] arr;
        private static char[] permutations;
        private static bool[] used;

        static void Main(string[] args)
        {
            arr = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(char.Parse)
                 .ToArray();

            permutations = new char[arr.Length];
            used = new bool[arr.Length];

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    permutations[index] = arr[i];
                    Permute(index + 1);
                    used[i] = false;
                }      
            }
        }
    }
}
