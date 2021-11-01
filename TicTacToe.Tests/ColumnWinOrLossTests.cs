using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class ColumnWinOrLossTests
    {

        private readonly Model.Board _sut;

        public ColumnWinOrLossTests()
        {
            _sut = new Model.Board();
        }

        [Fact]
        public void FullFirstColumnIsWin()
        {
            _sut.SetPiece("X", 0, 0);
            _sut.SetPiece("X", 1, 0);
            _sut.SetPiece("X", 2, 0);

            Assert.True(_sut.CheckColumnForWin("X", 0));
        }

        [Fact]
        public void TwoInFirstColumnIsLoss()
        {
            _sut.SetPiece("X", 0, 0);
            _sut.SetPiece("X", 1, 0);
            _sut.SetPiece("Y", 2, 0);

            Assert.False(_sut.CheckColumnForWin("X", 0));
        }

        [Fact]
        public void FullSecondColumnIsWin()
        {
            _sut.SetPiece("X", 0, 1);
            _sut.SetPiece("X", 1, 1);
            _sut.SetPiece("X", 2, 1);

            Assert.True(_sut.CheckColumnForWin("X", 1));
        }

        [Fact]
        public void TwoInSecondColumnIsLoss()
        {
            _sut.SetPiece("X", 0, 1);
            _sut.SetPiece("X", 1, 1);
            _sut.SetPiece("Y", 2, 1);

            Assert.False(_sut.CheckColumnForWin("X", 1));
        }
        [Fact]
        public void FullThirdRowIsWin()
        {
            _sut.SetPiece("X", 0, 2);
            _sut.SetPiece("X", 1, 2);
            _sut.SetPiece("X", 2, 2);

            Assert.True(_sut.CheckColumnForWin("X", 2));
        }

        [Fact]
        public void TwoInThirdColumnIsLoss()
        {
            _sut.SetPiece("X", 2, 0);
            _sut.SetPiece("X", 2, 1);
            _sut.SetPiece("Y", 2, 2);

            Assert.False(_sut.CheckColumnForWin("X", 2));
        }
    }
}
