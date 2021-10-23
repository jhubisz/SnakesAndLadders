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
    }
}
