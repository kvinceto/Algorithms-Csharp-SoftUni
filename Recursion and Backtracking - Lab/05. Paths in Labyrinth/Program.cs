using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Paths_in_Labyrinth
{
    public class Program
    {

        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine());
            int columnCount = int.Parse(Console.ReadLine());
            char[,] field = new char[rowCount, columnCount];

            for (int row = 0; row < rowCount; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < columnCount; col++)
                {
                    field[row, col] = data[col];
                }
            }

            FindPaths(field, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] field, int row, int col, List<string> directions, string direction)
        {
            //Validate row and col
            if (row < 0 || row >= field.GetLength(0) || col < 0 || col >= field.GetLength(1))
            {
                return;
            }

            //Validate walls or visited cells
            if (field[row, col] == '*' || field[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            //Check for end
            if (field[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            field[row, col] = 'v';

            FindPaths(field, row - 1, col, directions, "U");
            FindPaths(field, row + 1, col, directions, "D");
            FindPaths(field, row, col - 1, directions, "L");
            FindPaths(field, row, col + 1, directions, "R");

            field[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
