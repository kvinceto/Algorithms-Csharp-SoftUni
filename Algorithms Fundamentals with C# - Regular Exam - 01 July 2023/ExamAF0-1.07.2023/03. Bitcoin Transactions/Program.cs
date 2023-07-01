namespace _03._Bitcoin_Transactions
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(' ');
            string[] array2 = Console.ReadLine().Split(' ');

            string[] longestSequence = FindLongestSequence(array1, array2);

            Console.WriteLine($"[{string.Join(" ", longestSequence)}]");
        }

        static string[] FindLongestSequence(string[] array1, string[] array2)
        {
            int[,] dp = new int[array1.Length + 1, array2.Length + 1];
            int maxLength = 0;
            int endIndex = 0;

            for (int i = 1; i <= array1.Length; i++)
            {
                for (int j = 1; j <= array2.Length; j++)
                {
                    if (array1[i - 1] == array2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;

                        if (dp[i, j] > maxLength)
                        {
                            maxLength = dp[i, j];
                            endIndex = i - 1;
                        }
                    }
                }
            }

            List<string> sequence = new List<string>();

            while (maxLength > 0)
            {
                sequence.Add(array1[endIndex]);
                endIndex--;
                maxLength--;
            }

            sequence.Reverse();

            return sequence.ToArray();
        }
    }


}
