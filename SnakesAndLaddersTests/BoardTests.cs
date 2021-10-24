using SnakesAndLadders;
using SnakesAndLadders.Fields;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class BoardTests
    {
        private const int MAX_PLAYERS = 2;
        private const int NO_OF_FIELDS = 100;
        private const int DICE_NUMBER_OF_SIDES = 6;

        public Board Board { get; set; }

        public BoardTests()
        {
            var randomThrows = new int[] { 6 };
            InitializeBoard(randomThrows);
        }

        private void InitializeBoard(int[] randomThrows)
        {
            var randomGenerator = new RandomGeneratorMock(randomThrows);
            var dice = new Dice(DICE_NUMBER_OF_SIDES, randomGenerator);

            Board = new Board(NO_OF_FIELDS, MAX_PLAYERS, dice);
        }

        [Fact]
        public void BoardIsCreatedAndHasSpecifiedNoOfFields()
        {
            Assert.Equal(NO_OF_FIELDS, Board.Fields.Count);
        }

        [Fact]
        public void BoardHasFieldsInFieldsCollection()
        {
            Assert.All(Board.Fields, f => Assert.IsAssignableFrom<IField>(f));
        }
    }
}
