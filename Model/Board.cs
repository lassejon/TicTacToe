using System;
using System.Text;

namespace Model
{
    public class Board
    {
        private string[,] Rows { get; set; }
        private int CountBoardPieces { get; set; }
        private const int MaxPieces = 9;
        private const int Size = 3;

        public Board()
        {
            Rows = new string[Size, Size];
            CountBoardPieces = 0;
        }

        public bool SetPiece(string piece, int posX, int posY)
        {
            if (!IsValidPosition(posX, posY)) return false;

            CountBoardPieces++;
            Rows[posX, posY] = piece;
            return true;
        }

        public bool IsValidPosition(int posX, int posY)
        {
            var maxPos = Rows.GetLength(0) - 1;
            var minPos = 0;
            var positionsInsideBoard = (posX <= maxPos && posY <= maxPos) && (posX >= minPos && posY >= minPos);
            
            return positionsInsideBoard && Rows[posX, posY] is null;
        }

        public void ResetGame()
        {
            Rows = new string[Size, Size];
            CountBoardPieces = 0;
        }

        public bool IsGameOver(string piece, int posX, int posY)
        {
            if (CountBoardPieces < MaxPieces)
            {
                return CheckRowForWin(piece, posX) || CheckColumnForWin(piece, posY) ||
                       CheckDiagonalForWin(piece) || CheckOtherDiagonalForWin(piece);
            }

            Console.WriteLine();
            Console.WriteLine("Game is draw!");
            return true;

        }

        public bool CheckColumnForWin(string piece, int posY)
        {
            for (var i = 0; i < Size; i++)
            {
                if (piece != Rows[i, posY])
                {
                    return false;
                }
            }
            
            Console.WriteLine();
            Console.WriteLine($"{piece} wins BIG TIME!!!!!!!");

            return true;
        }

        public bool CheckRowForWin(string piece, int posX)
        {
            for (var i = 0; i < Size; i++)
            {
                if (piece != Rows[posX, i])
                {
                    return false;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"{piece} wins BIG TIME!!!!!!!");
            
            return true;
        }

        public bool CheckDiagonalForWin(string piece)
        {
            for (var i = 0; i < Size; i++)
            {
                if (piece != Rows[i, i])
                {
                    return false;
                }
            }
            
            Console.WriteLine();
            Console.WriteLine($"{piece} wins BIG TIME!!!!!!!");

            return true;
        }

        public bool CheckOtherDiagonalForWin(string piece)
        {
            for (var i = 0; i < Size; i++)
            {
                if (piece != Rows[i, (Size - 1) - i])
                {
                    return false;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"{piece} wins BIG TIME!!!!!!!");

            return true;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new();

            for (var i = 0; i < Rows.GetLength(0); i++) 
            {
                sb.Append("|");
                for (var j = 0; j < Rows.GetLength(1); j++) 
                {
                    sb.Append(Rows[i, j] ?? " ");
                    sb.Append("|");
                }
                sb.Append(i != Rows.GetLength(1) - 1 ? "\n" : "");
            }

            return sb.ToString();
        }
    }
}