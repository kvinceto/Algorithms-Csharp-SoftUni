namespace _01._Reverse_Array
{
    using System;
    using System.Linq;

    public class Program
    {

        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ReverseArray(inputArr, 0, inputArr.Length - 1);

            Console.WriteLine(string.Join(" ", inputArr));
        }

        private static void ReverseArray(int[] inputArr, int indexStart, int indexEnd)
        {
            if (indexStart >= indexEnd)
            {
                return;
            }

            ReverseArray(inputArr, indexStart + 1, indexEnd - 1);
            var temp = inputArr[indexStart];
            var temp2 = inputArr[indexEnd];
            inputArr[indexStart] = temp2;
            inputArr[indexEnd] = temp;
        }
    }
}
