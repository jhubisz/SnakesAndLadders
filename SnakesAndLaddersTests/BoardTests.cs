using SnakesAndLadders;
using SnakesAndLadders.Enums;
using SnakesAndLadders.Fields;
using SnakesAndLaddersTests.Mocks;
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
            var configuration = new FieldsConfigurationMock();

            Board = new Board(NO_OF_FIELDS, MAX_PLAYERS, dice, configuration);
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

        [Fact]
        public void BoardHasLaddersBasedOnPassedInConfiguration()
        {
            int ladder1FieldNumber = 10;
            int ladder2FieldNumber = 20;
            Assert.IsAssignableFrom<LadderField>(Board.GetField(ladder1FieldNumber));
            Assert.IsAssignableFrom<LadderField>(Board.GetField(ladder2FieldNumber));
        }

        [Fact]
        public void BoardHasSnakesBasedOnPassedInConfiguration()
        {
            int snake1FieldNumber = 12;
            int snake2FieldNumber = 50;
            Assert.IsAssignableFrom<SnakeField>(Board.GetField(snake1FieldNumber));
            Assert.IsAssignableFrom<SnakeField>(Board.GetField(snake2FieldNumber));
        }

        [Fact]
        public void BoardHoldsCorrectGameStateAfterInitialization()
        {
            Assert.Equal(GameState.Ongoing, Board.GameState);
        }
    }
}
