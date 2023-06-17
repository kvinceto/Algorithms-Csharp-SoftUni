namespace _06._Merge_Sort
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
             .Split(' ')
             .Select(int.Parse)
             .ToArray();

            var sorted = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }

            var left = numbers.Take(numbers.Length / 2).ToArray();
            var right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergedIndex = 0;
            var leftIndex = 0;
            var rightdIndex = 0;


            while (leftIndex < left.Length && rightdIndex < right.Length)
            {
                if (left[leftIndex] < right[rightdIndex])
                {
                    merged[mergedIndex++] = left[leftIndex++];
                }
                else
                {
                    merged[mergedIndex++] = right[rightdIndex++];
                }
            }

            for (int i = leftIndex; i < left.Length; i++)
            {
                merged[mergedIndex++] = left[i];
            }

            for(int i = rightdIndex; i < right.Length; i++)
            {
                merged[mergedIndex++] = right[i];
            }

            return merged;
        }
    }
}
