using SnakesAndLadders;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class BoardTests
    {
        const int NO_OF_FIELDS = 100;

        [Fact]
        public void BoardIsCreatedAndHasSpecifiedNoOfFields()
        {    
            var board = new Board(NO_OF_FIELDS);

            Assert.Equal(NO_OF_FIELDS, board.Fields.Count);
        }
    }
}
