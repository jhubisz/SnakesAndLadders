using SnakesAndLadders;
using SnakesAndLadders.Fields;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class BoardTests
    {
        const int NO_OF_FIELDS = 100;

        public Board Board { get; set; }

        public BoardTests()
        {
            Board = new Board(NO_OF_FIELDS);
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
        public void BoardAllowsForAddingAPlayer()
        {
            var playerName = "Name";
            var player = new Player(playerName);

            Board.AddPlayer(player);

            Assert.Collection(Board.Players, p => Assert.Equal(player, p));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(66)]
        [InlineData(100)]
        public void BoardReturnsCorrectFieldBasedOnNumber(int fieldNo)
        {
            IField field = Board.GetField(fieldNo);

            Assert.Equal(fieldNo, field.FieldNumber);
        }
    }
}
