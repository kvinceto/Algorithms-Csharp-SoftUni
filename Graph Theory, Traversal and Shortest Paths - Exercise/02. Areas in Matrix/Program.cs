using System;

namespace _02._Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            var areas = FindAreas(matrix);

            Console.WriteLine("Areas: " + areas.Count);

            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        static Dictionary<char, int> FindAreas(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            var visited = new bool[rows, cols];
            var areas = new Dictionary<char, int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!visited[i, j])
                    {
                        char letter = matrix[i, j];
                        int areaSize = DFS(matrix, visited, i, j, letter);
                        if (!areas.ContainsKey(letter))
                        {
                            areas[letter] = 0;
                        }
                        areas[letter]++;
                    }
                }
            }

            return areas;
        }

        static int DFS(char[,] matrix, bool[,] visited, int row, int col, char letter)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return 0;
            }

            if (visited[row, col] || (matrix[row, col] != letter))
            {
                return 0;
            }

            visited[row, col] = true;

            int areaSize = 1;
            areaSize += DFS(matrix, visited, row - 1, col, letter); // up
            areaSize += DFS(matrix, visited, row + 1, col, letter); // down
            areaSize += DFS(matrix, visited, row, col - 1, letter); // left
            areaSize += DFS(matrix, visited, row, col + 1, letter); // right

            return areaSize;
        }
    }

}
