namespace _06.EightQueensPuzzle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Chessboard
    {
        private const int Size = 8;

        private bool[,] matrix = new bool[Size, Size];

        public Chessboard()
        {
            matrix = CreateEmptyChessBoard();
            AttackedRows = new Stack<int>();
            AttackedCols = new Stack<int>();
            AttackedLeftDiagonal = new Stack<int>();
            AttackedRightDiagonal = new Stack<int>();
        }

        public Stack<int> AttackedRows { get; private set; }
        public Stack<int> AttackedCols { get; private set; }
        public Stack<int> AttackedLeftDiagonal { get; private set; }
        public Stack<int> AttackedRightDiagonal { get; private set; }

        private bool[,] CreateEmptyChessBoard()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    this.matrix[row, col] = false;
                }
            }

            return this.matrix;
        }

        public void PlaceQueen(int row)
        {
            if (row >= Size)
            {

                PrintChessBoard();
                Console.WriteLine();
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAttackedCells(row, col);

                        PlaceQueen(row + 1);

                        UnmarkAttackedCells(row, col);
                    }
                }
            }
        }

        private void UnmarkAttackedCells(int row, int col)
        {
            AttackedRows.Pop();
            AttackedCols.Pop();
            AttackedLeftDiagonal.Pop();
            AttackedRightDiagonal.Pop();
            UnmarkОccupiedCell(row, col);
        }

        private void MarkAttackedCells(int row, int col)
        {
            int leftDiagonalNumber = row + col;
            int rightDiagonalNumber = row - col;

            AttackedRows.Push(row);
            AttackedCols.Push(col);
            AttackedLeftDiagonal.Push(leftDiagonalNumber);
            AttackedRightDiagonal.Push(rightDiagonalNumber);
            MarkAsОccupiedCell(row, col);
        }

        private void UnmarkОccupiedCell(int row, int col)
        {
            this.matrix[row, col] = false;
        }

        private void MarkAsОccupiedCell(int row, int col)
        {
            this.matrix[row, col] = true;
        }

        private void PrintChessBoard()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (matrix[row, col])
                    {
                        result.Append('*' + " ");
                    }
                    else
                    {
                        result.Append('-' + " ");
                    }
                }

                result.AppendLine();
            }

            Console.Write(result.ToString());
        }

        private bool CanPlaceQueen(int row, int col)
        {
            int leftDiagonalNumber = row + col;
            int rightDiagonalNumber = row - col;
            bool isPossibleMove = !AttackedRows.Contains(row)
                               && !AttackedCols.Contains(col)
                               && !AttackedLeftDiagonal.Contains(leftDiagonalNumber)
                               && !AttackedRightDiagonal.Contains(rightDiagonalNumber);

            return isPossibleMove;
        }
    }

    public class Program
    {
        static void Main()
        {
            Chessboard chessBoard = new Chessboard();

            chessBoard.PlaceQueen(0);
        }
    }
}
