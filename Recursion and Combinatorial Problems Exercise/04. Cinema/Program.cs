namespace _04._Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] locked;

        static void Main(string[] args)
        {
            nonStaticPeople = Console.ReadLine().Split(", ").ToList();
            people = new string[nonStaticPeople.Count];
            locked = new bool[nonStaticPeople.Count];

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "generate")
                {
                    break;
                }

                var parts = line.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                people[position] = name;
                locked[position] = true;

                nonStaticPeople.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= nonStaticPeople.Count)
            {
                Print();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Print()
        {
            var peopleIndex = 0;
            var sb = new StringBuilder();

            for (int i = 0; i < people.Length; i++)
            {
                if (!locked[i])
                {
                    people[i] = nonStaticPeople[peopleIndex++];
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static void Swap(int firstIndex, int secondIndex)
        {
            var temp = nonStaticPeople[firstIndex];
            nonStaticPeople[firstIndex] = nonStaticPeople[secondIndex];
            nonStaticPeople[secondIndex] = temp;
        }
    }
}
