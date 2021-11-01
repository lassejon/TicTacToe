using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class RowWinOrLossTests
    {

        private readonly Model.Board _sut;

        public RowWinOrLossTests()
        {
            _sut = new Model.Board();

        }

        [Fact]
        public void FullFirstRowIsWin()
        {
            _sut.SetPiece("X", 0, 0);
            _sut.SetPiece("X", 0, 1);
            _sut.SetPiece("X", 0, 2);

            Assert.True(_sut.CheckRowForWin("X", 0));
        }

        [Fact]
        public void TwoInFirstRowIsLoss()
        {
            _sut.SetPiece("X", 0, 0);
            _sut.SetPiece("X", 0, 1);

            Assert.False(_sut.CheckRowForWin("X", 0));
        }

        [Fact]
        public void FullSecondRowIsWin()
        {
            _sut.SetPiece("X", 1, 0);
            _sut.SetPiece("X", 1, 1);
            _sut.SetPiece("X", 1, 2);

            Assert.True(_sut.CheckRowForWin("X", 1));
        }

        [Fact]
        public void TwoInSecondRowIsLoss()
        {
            _sut.SetPiece("X", 1, 0);
            _sut.SetPiece("X", 1, 1);

            Assert.False(_sut.CheckRowForWin("X", 1));
        }
        [Fact]
        public void FullThirdRowIsWin()
        {
            _sut.SetPiece("X", 2, 0);
            _sut.SetPiece("X", 2, 1);
            _sut.SetPiece("X", 2, 2);

            Assert.True(_sut.CheckRowForWin("X", 2));
        }

        [Fact]
        public void TwoInThirdRowIsLoss()
        {
            _sut.SetPiece("X", 2, 0);
            _sut.SetPiece("X", 2, 1);

            Assert.False(_sut.CheckRowForWin("X", 2));
        }
    }
}

