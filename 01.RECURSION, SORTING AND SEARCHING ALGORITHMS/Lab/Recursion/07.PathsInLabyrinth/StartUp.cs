namespace _07.PathsInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static List<char> paths = new List<char>();
        public static char[,] labyrinth = GetLabyrinth();

        public const char right = 'R';
        public const char left = 'L';
        public const char up = 'U';
        public const char down = 'D';
        public const char visitedCell = 'v';
        public const char emptyCell = '-';
        public const char finalCell = 'e';

        const int startRow = 0;
        const int startCol = 0;

        public static void Main()
        {
            FindPath(startRow, startCol, right);
        }

        private static void FindPath(int row, int col, char direction)
        {
            if (!IsInBoundsOfLabyrinth(row, col))
            {
                return;
            }

            paths.Add(direction);

            if (IsExitOfLabyrinth(row, col))
            {
                PrintPath();

            }
            else if (!IsVisited(row, col) && IsFreeToMove(row, col))
            {
                MarkAsVisited(row, col);
                FindPath(row, col + 1, right);
                FindPath(row + 1, col, down);
                FindPath(row, col - 1, left);
                FindPath(row - 1, col, up);
                UnMark(row, col);
            }

            paths.RemoveAt(paths.Count - 1);
        }

        private static void UnMark(int row, int col)
        {
            labyrinth[row, col] = emptyCell;
        }

        private static void MarkAsVisited(int row, int col)
        {
            labyrinth[row, col] = visitedCell;
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", paths.Skip(1)));

        }

        private static bool IsExitOfLabyrinth(int row, int col)
        {
            return labyrinth[row, col] == finalCell;
        }

        private static bool IsFreeToMove(int row, int col)
        {
            return labyrinth[row, col] == emptyCell || labyrinth[row, col] == finalCell;
        }

        private static bool IsVisited(int row, int col)
        {
            return labyrinth[row, col] == visitedCell;
        }

        private static bool IsInBoundsOfLabyrinth(int row, int col)
        {
            bool isInBoundes = (row >= 0 && row < labyrinth.GetLength(0))
                               && (col >= 0 && col < labyrinth.GetLength(1));

            return isInBoundes;
        }

        private static char[,] GetLabyrinth()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentrow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = currentrow[col];
                }
            }

            return labyrinth;
        }
    }
}

