using System;
using Model;

namespace View
{
    public class Game
    {
        private string PieceX { get; set; }
        private string PieceY { get; set; }
        private Board Board { get; set; }
        
        public Game()
        {
            Board = new Board();
        }

        private void ChoosePieces()
        {
            Console.WriteLine("Lets play some Tic Tac and the Toes!");
            Console.WriteLine();

            PieceX = ChoosePiece();
            
            PieceY = ChoosePiece(PieceX);
        }

        private string ChoosePiece(string pieceOpposite = " ")
        {
            var piece = "";
            var isValid = true;
            
            do
            {
                PrintIfNotValidPiece(pieceOpposite, isValid, piece);
                
                Console.WriteLine("Select a character to represent your piece");

                piece = Console.ReadLine();
                if (piece != null) isValid = piece.Length == 1;
            } while (!isValid || piece == pieceOpposite);

            return piece;
        }

        private void PrintIfNotValidPiece(string pieceOpposite, bool isValid, string piece)
        {
            if (isValid && piece != pieceOpposite) return;
            
            Console.WriteLine($"Input {piece} is not valid. Pick another character");
        }

        private (int, int) MakeMove(string piece)
        {
            var isValid = true;
            int posX;
            int posY;
            do
            {
                PrintIfNotValidMove(isValid);
                
                Console.WriteLine("Choose a position to place your piece!");
                Console.Write("Choose two numbers between 0 and 2 seperated by space (e.g. 0 2): ");

                var input = Console.ReadLine();
                isValid = IsValidMove(input, out posX, out posY);
            } while (!isValid);
            
            Board.SetPiece(piece, posX, posY);

            return (posX, posY);
        }

        public void PlayGame()
        {
            ChoosePieces();
            
            int posX;
            int posY;
            
            do
            {
                (posX, posY) = MakeMove(PieceX);
                (PieceY, PieceX) = (PieceX, PieceY);
                Console.WriteLine(Board);

            } while (!Board.IsGameOver(PieceY, posX, posY));
        }

        private bool IsValidMove(string input, out int posX, out int posY)
        {
            if (input.Length is not 3)
            {
                (posX, posY) = (0, 0);
                return false;
            }

            if (input[1] != ' ')
            {
                (posX, posY) = (0, 0);
                return false;
            }
            
            var inputs = input.Split(' ');
            var parsed = int.TryParse(inputs[1], out posY) & int.TryParse(inputs[0], out posX);
            return Board.IsValidPosition(posX, posY) && parsed;
                
        }

        private void PrintIfNotValidMove(bool isValid)
        {
            if (isValid) return;
            
            Console.WriteLine($"Input is not valid. Try again dummy.");
        }
    }
}