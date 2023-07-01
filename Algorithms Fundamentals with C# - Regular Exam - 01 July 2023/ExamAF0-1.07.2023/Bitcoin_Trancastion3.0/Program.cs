namespace Bitcoin_Trancastion3._0
{
    using System;
    using System.Collections.Generic;

    namespace Bitcoin_Transactions
    {
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
                        else
                        {
                            dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                        }
                    }
                }

                int row = array1.Length;
                int col = array2.Length;
                var longestSequence = new List<string>();

                while (row > 0 && col > 0)
                {
                    if (array1[row - 1] == array2[col - 1])
                    {
                        longestSequence.Insert(0, array1[row - 1]);
                        row--;
                        col--;
                    }
                    else if (dp[row - 1, col] > dp[row, col - 1])
                    {
                        row--;
                    }
                    else
                    {
                        col--;
                    }
                }

                return longestSequence.ToArray();
            }
        }
    }

}
