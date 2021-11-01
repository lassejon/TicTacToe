using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class DiagonalsWinOrLossTests
    {

        private readonly Model.Board _sut;

        public DiagonalsWinOrLossTests()
        {
            _sut = new Model.Board();
        }

        [Fact]
        public void FullDiagonalIsWin()
        {
            _sut.SetPiece("X", 0, 0);
            _sut.SetPiece("X", 1, 1);
            _sut.SetPiece("X", 2, 2);

            Assert.True(_sut.CheckDiagonalForWin("X"));
        }

        [Fact]
        public void TwoInDiagonalIsLoss()
        {
            _sut.SetPiece("X", 0, 0);
            _sut.SetPiece("X", 1, 1);
            _sut.SetPiece("Y", 2, 2);

            Assert.False(_sut.CheckDiagonalForWin("X"));
        }

        [Fact]
        public void FullOtherDiagonalIsWin()
        {
            _sut.SetPiece("X", 0, 2);
            _sut.SetPiece("X", 1, 1);
            _sut.SetPiece("X", 2, 0);

            Assert.True(_sut.CheckDiagonalForWin("X"));
        }

        [Fact]
        public void TwoInOtherDiagonalIsLoss()
        {
            _sut.SetPiece("X", 0, 2);
            _sut.SetPiece("X", 1, 1);
            _sut.SetPiece("Y", 2, 0);

            Assert.False(_sut.CheckDiagonalForWin("X"));
        }
    }
}

