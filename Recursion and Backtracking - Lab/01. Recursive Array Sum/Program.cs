using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(GetSum(arr, 0));
        }

        private static int GetSum(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                return 0;
            }

            return arr[index] + GetSum(arr, index + 1);
        }
    }
}
