using SnakesAndLadders;
using SnakesAndLadders.Enums;
using SnakesAndLadders.Fields;
using SnakesAndLaddersTests.Mocks;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class BoardPlayersTests
    {
        private const int MAX_PLAYERS = 2;
        private const int NO_OF_FIELDS = 100;
        private const int FIRST_FIELD = 1;
        private const int DICE_NUMBER_OF_SIDES = 6;

        public Board Board { get; set; }

        public BoardPlayersTests()
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
        private Player AddPlayerToBoard(string playerName)
        {
            var player = new Player(playerName);
            Board.AddPlayer(player);
            return player;
        }

        [Fact]
        public void BoardAllowsForAddingAPlayer()
        {
            var playerName = "Name";
            var player = AddPlayerToBoard(playerName);

            Assert.Collection(Board.Players, p => Assert.Equal(player, p.Key));
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

        [Fact]
        public void BoardSetsInitialPlayerPositionCorrectly()
        {
            var firstField = Board.GetField(FIRST_FIELD);
            var player = AddPlayerToBoard("Name");

            Assert.Equal(firstField, Board.Players[player]);
        }

        [Fact]
        public void BoardChangesPlayerPositionBasedOnDiceThrow()
        {
            var randomThrows = new int[] { 6 };
            InitializeBoard(randomThrows);
            var player = AddPlayerToBoard("Name");

            Board.MovePlayer();

            Assert.Equal(FIRST_FIELD + randomThrows[0], Board.Players[player].FieldNumber);
        }

        [Fact]
        public void ChangesCurrentPlayerAfterMoveIsMade()
        {
            var randomThrows = new int[] { 6 };
            InitializeBoard(randomThrows);
            AddPlayerToBoard("Player 1");
            var player2 = AddPlayerToBoard("Player 2");

            Board.MovePlayer();

            Assert.Equal(player2, Board.CurrentTurnPlayer);
        }

        [Fact]
        public void PlayerIsMovedByLadder()
        {
            var randomThrows = new int[] { 5, 4 };
            InitializeBoard(randomThrows);
            AddPlayerToBoard("player");

            var targetFieldAfterTwoMoves = 99;

            Board.MovePlayer();
            Board.MovePlayer();

            Assert.Equal(targetFieldAfterTwoMoves, Board.Players[Board.CurrentTurnPlayer].FieldNumber);
        }

        [Fact]
        public void PlayerIsMovedBySnake()
        {
            var randomThrows = new int[] { 6, 5 };
            InitializeBoard(randomThrows);
            AddPlayerToBoard("player");

            var targetFieldAfterTwoMoves = 2;

            Board.MovePlayer();
            Board.MovePlayer();

            Assert.Equal(targetFieldAfterTwoMoves, Board.Players[Board.CurrentTurnPlayer].FieldNumber);
        }


        [Fact]
        public void GameStateIsChangedToFinishedAfterPlayerReachesFinalField()
        {
            var randomThrows = new int[] { 5, 4, 1 };
            InitializeBoard(randomThrows);
            AddPlayerToBoard("player");

            Board.MovePlayer(); // moves to field 5
            Board.MovePlayer(); // takes ladder from field 10 to 99
            Board.MovePlayer(); // moves over final field

            Assert.Equal(GameState.Finished, Board.GameState);
        }
    }
}
