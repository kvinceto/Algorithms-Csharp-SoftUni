using System;
using System.Collections.Generic;

namespace _01._Fibonacci
{
    public class Program
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFib(n));
        }

        private static long CalcFib(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }

            var result = CalcFib(n - 1) + CalcFib(n - 2);
            cache[n] = result;
            return result;
        }
    }
}
