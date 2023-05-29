using System;

namespace _02._Recursive_Drawing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Print(n);
        }

        private static void Print(int n)
        {
            if (n < 1)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            Print(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
