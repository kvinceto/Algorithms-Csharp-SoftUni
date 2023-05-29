using System;

namespace _07._Recursive_Fibonacci
{
    public class Program
    {
        static void Main(string[] args)
        {
            int fibonacciNumber = int.Parse(Console.ReadLine());


            Console.WriteLine(GetFibonacciNumber(fibonacciNumber));
        }

        private static int GetFibonacciNumber(int fibonacciNumber)
        {
            if (fibonacciNumber <= 1)
            {
                return 1;
            }

            return GetFibonacciNumber(fibonacciNumber - 1) + GetFibonacciNumber(fibonacciNumber - 2);
        }
    }
}
