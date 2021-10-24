using SnakesAndLadders;
using SnakesAndLadders.Exceptions;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class PlayerCollectionTests
    {
        [Fact]
        public void AllowsAddingOfFirstPlayer()
        {
            var maxPlayers = 2;
            var playerCollection = new PlayerCollection(maxPlayers);
            var player = new Player("player");
            playerCollection.Add(player);

            Assert.Equal(player, playerCollection.CurrentPlayer);
        }

        [Fact]
        public void AllowsAddingOfMaxNumberOfPlayers()
        {
            var maxPlayers = 2;
            var playerCollection = new PlayerCollection(maxPlayers);
            var player1 = new Player("player1");
            var player2 = new Player("player2");
            playerCollection.Add(player1);
            playerCollection.Add(player2);

            Assert.Equal(player2, playerCollection[1]);
        }

        [Fact]
        public void ThrowsExceptionWhenNumberOfPlayersIsExceeded()
        {
            var maxPlayers = 2;
            var playerCollection = new PlayerCollection(maxPlayers);
            var player1 = new Player("player1");
            var player2 = new Player("player2");
            var player3 = new Player("player3");
            playerCollection.Add(player1);
            playerCollection.Add(player2);

            Assert.Throws<NumberOfPlayersExceededException>(() => playerCollection.Add(player3));
        }

        [Fact]
        public void AlternatesToSecondPlayer()
        {
            var maxPlayers = 2;
            var playerCollection = new PlayerCollection(maxPlayers);
            var player1 = new Player("player1");
            var player2 = new Player("player2");
            playerCollection.Add(player1);
            playerCollection.Add(player2);

            playerCollection.NextPlayer();

            Assert.Equal(player2, playerCollection.CurrentPlayer);
        }

        [Fact]
        public void AlternatesToThirdPlayer()
        {
            var maxPlayers = 3;
            var playerCollection = new PlayerCollection(maxPlayers);
            var player1 = new Player("player1");
            var player2 = new Player("player2");
            var player3 = new Player("player3");
            playerCollection.Add(player1);
            playerCollection.Add(player2);
            playerCollection.Add(player3);

            playerCollection.NextPlayer();
            playerCollection.NextPlayer();

            Assert.Equal(player3, playerCollection.CurrentPlayer);
        }

        [Fact]
        public void AlternatesBackToFirstPlayer()
        {
            var maxPlayers = 5;
            var playerCollection = new PlayerCollection(maxPlayers);
            var player1 = new Player("player1");
            var player2 = new Player("player2");
            var player3 = new Player("player3");
            playerCollection.Add(player1);
            playerCollection.Add(player2);
            playerCollection.Add(player3);

            playerCollection.NextPlayer();
            playerCollection.NextPlayer();
            playerCollection.NextPlayer();

            Assert.Equal(player1, playerCollection.CurrentPlayer);
        }
    }
}
