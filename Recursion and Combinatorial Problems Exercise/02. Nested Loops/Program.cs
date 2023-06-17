namespace _02._Nested_Loops
{
    using System;

    public class Program
    {
        private static int[] elements;

        static void Main(string[] args)
        {
            GetElements();
            Combinations(new int[elements.Length], 0, 0); // n
        }

        private static void Combinations(int[] combination, int index, int border)
        {
            if (index == combination.Length)
            {
                Print(combination);
            }
            else
            {
                for (int current = 0; current < elements.Length; current++)
                {
                    combination[index] = elements[current];

                    Combinations(combination, index + 1, current);
                }
            }
        }
        private static void Print(int[] combination)
           => Console.WriteLine(string.Join(" ", combination));

        private static void GetElements()
        {
            var n = int.Parse(Console.ReadLine());
            elements = new int[n];

            for (int i = 0; i < n; i++)
            {
                elements[i] = i + 1;
            }
        }
    }
}
