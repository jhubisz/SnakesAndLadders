using SnakesAndLadders;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerHasNameAssignedInConstructor()
        {
            var playerName = "Name";
            var player = new Player(playerName);

            Assert.Equal(playerName, player.Name);
        }
    }
}
