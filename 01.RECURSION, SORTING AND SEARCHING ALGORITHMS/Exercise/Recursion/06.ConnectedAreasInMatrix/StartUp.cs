namespace _06.ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cell
    {
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }

    public class Area
    {
        public Area(int row, int col)
        {
            this.StartingRow = row;
            this.StartingCol = col;
        }

        public int StartingRow { get; set; }

        public int StartingCol { get; set; }

        public int Size { get; set; }

    }

    public class StartUp
    {
        public static void Main()
        {
            var rowsCount = int.Parse(Console.ReadLine());
            var colsCount = int.Parse(Console.ReadLine());

            var matrix = GetMatrix(rowsCount, colsCount);
            var areas = new List<Area>();

            var startOfAreaCell = FindStartOfArea(matrix);

            while (startOfAreaCell != null)
            {
                var area = new Area(startOfAreaCell.Row, startOfAreaCell.Col);
                area.Size = FindConnectedArea(matrix, area.StartingRow, area.StartingCol);
                areas.Add(area);
                startOfAreaCell = FindStartOfArea(matrix);
            }

            PrintResult(areas);
        }

        private static Cell FindStartOfArea(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (!CellIsMarked(matrix, row, col))
                    {
                        return new Cell(row, col);
                    }
                }
            }

            return null;
        }

        private static int FindConnectedArea(char[][] matrix, int row, int col)
        {

            if (CellIsOutsideTheMatrix(matrix, row, col)
                || CellIsMarked(matrix, row, col))
            {
                return 0;
            }

            MarkCell(matrix, row, col);
            return 1
                + FindConnectedArea(matrix, row, col - 1)
                + FindConnectedArea(matrix, row - 1, col)
                + FindConnectedArea(matrix, row, col + 1)
                + FindConnectedArea(matrix, row + 1, col);
        }

        private static bool CellIsMarked(char[][] matrix, int row, int col)
        {
            return matrix[row][col] == '*' || matrix[row][col] == 'v';
        }

        private static bool CellIsAreaBorder(char[][] matrix, int row, int col)
        {
            return matrix[row][col] == '*';
        }

        private static void MarkCell(char[][] matrix, int row, int col)
        {
            matrix[row][col] = 'v';
        }

        private static bool CellIsOutsideTheMatrix(char[][] matrix, int startingRow, int startingCol)
        {
            return startingRow >= matrix.Length
                    || startingCol >= matrix[0].Length
                    || startingRow < 0
                    || startingCol < 0;
        }

        private static char[][] GetMatrix(int rowsCount, int colsCount)
        {
            var matrix = new char[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = new char[colsCount];
                var currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row][col] = currentRow[col];
                }
            }

            return matrix;
        }

        private static void PrintResult(List<Area> areas)
        {
            int count = 1;
            var sb = new StringBuilder();
            sb.AppendLine($"Total areas found: {areas.Count}");

            foreach (var area in areas.OrderByDescending(x => x.Size)
                                     .ThenBy(y => y.StartingRow)
                                     .ThenBy(z => z.StartingCol))
            {
                sb.AppendLine($"Area #{count++} at ({area.StartingRow}, {area.StartingCol}), size: {area.Size}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
