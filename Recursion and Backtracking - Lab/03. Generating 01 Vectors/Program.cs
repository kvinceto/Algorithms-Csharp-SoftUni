using System;

namespace _03._Generating_01_Vectors
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            FillArray(arr, 0);
        }

        private static void FillArray(int[] arr, int n)
        {
            if (n >= arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    arr[n] = i;
                    FillArray(arr, n + 1);
                }
            }
        }
    }
}
