using System;
using Microsoft.VisualBasic;
using Model;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            board.SetPiece("O", 0, 2);
            board.SetPiece("X", 1, 1);
            Console.WriteLine(board.SetPiece("O", 1, 1));

            Console.WriteLine(board);
        }
    }
}