using System;

namespace _04._Recursive_Factorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Result(n));
        }

        private static int Result(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Result(n - 1);
        }
    }
}
