using System;

namespace _01._Bitcoin_Miners
{
    public class Program
    {
        private static int[][] triangle;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var x = int.Parse(Console.ReadLine());

            InitializePascalsTriangle(n);
            Console.WriteLine(BinomialCoefficient(n, x));
        }

        private static long BinomialCoefficient(int n, int x)
        {
            if (x > n)
            {
                return 0;
            }

            if (x == 0 || x == n)
            {
                return 1;
            }

            return triangle[n][x] != 0
                ? triangle[n][x]
                : triangle[n][x] = ((int)(BinomialCoefficient(n - 1, x - 1) + BinomialCoefficient(n - 1, x)));
        }

        private static void InitializePascalsTriangle(int n)
        {
            triangle = new int[n + 1][];

            for (int row = 0; row <= n; row++)
            {
                triangle[row] = new int[row + 1];
            }
        }
    }
}
