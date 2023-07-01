namespace _01._Strings_Mashup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            char[] characters = Console.ReadLine().ToCharArray();
            int length = int.Parse(Console.ReadLine());

            List<string> combinations = GenerateCombinations(characters, length);

            combinations = combinations.OrderBy(c => c).ToList();

            foreach (string combination in combinations)
            {
                Console.WriteLine(combination);
            }
        }

        static List<string> GenerateCombinations(char[] characters, int length)
        {
            List<string> combinations = new List<string>();

            GenerateCombinationsRecursive(characters, length, "", 0, combinations);

            return combinations;
        }

        static void GenerateCombinationsRecursive(char[] characters, int length, string current, int index, List<string> combinations)
        {
            if (current.Length == length)
            {
                combinations.Add(current);
                return;
            }

            for (int i = index; i < characters.Length; i++)
            {
                string newCurrent = current + characters[i];
                GenerateCombinationsRecursive(characters, length, newCurrent, i, combinations);
            }
        }
    }

}
