using System;
using System.Runtime.InteropServices;
using Model;

namespace View
{
    public class Game
    {
        private char PieceX { get; set; }
        private char PieceY { get; set; }
        private Board Board { get; set; }
        
        public Game()
        {
            Board = new Board();
        }

        public void ChoosePieces()
        {
            Console.WriteLine("Lets play some Tic Tac and the Toes!");
            Console.WriteLine();
            System.Threading.Thread.Sleep(500);

            PieceX = ChoosePiece();
            System.Threading.Thread.Sleep(500);
            
            PieceY = ChoosePiece(PieceY);
            System.Threading.Thread.Sleep(500);
        }

        private char ChoosePiece(char pieceOpposite = ' ')
        {
            var piece = '\0';
            var isValid = true;
            
            do
            {
                PrintIfNotValidPiece(pieceOpposite, isValid, piece);
                
                Console.WriteLine("Select a character to represent your piece");

                piece = Console.ReadKey().KeyChar;
                isValid = char.IsLetter(piece);
            } while (!isValid || piece == pieceOpposite);

            return piece;
        }

        private static void PrintIfNotValidPiece(char pieceOpposite, bool isValid, char piece)
        {
            if (isValid && piece != pieceOpposite) return;
            
            Console.WriteLine($"Input {piece} is not valid. Pick another character");
            System.Threading.Thread.Sleep(500);
        }
    }
}