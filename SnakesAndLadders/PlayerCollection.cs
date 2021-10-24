using SnakesAndLadders.Exceptions;

namespace SnakesAndLadders
{
    public class PlayerCollection
    {
        private int currentPlayerIndex;
        private int lastAddedIndex;
        private Player[] players = new Player[100];

        public Player this[int i]
        {
            get => players[i];
            set => players[i] = value;
        }
        public int MaxPlayers { get; set; }

        public PlayerCollection(int maxPlayers)
        {
            MaxPlayers = maxPlayers;
        }

        public Player CurrentPlayer
        {
            get
            {
                return players[currentPlayerIndex];
            }
        }

        public void Add(Player player)
        {
            if (lastAddedIndex + 1 > MaxPlayers)
                throw new NumberOfPlayersExceededException();

            players[lastAddedIndex++] = player;
        }

        public void NextPlayer()
        {
            currentPlayerIndex++;
            if (currentPlayerIndex >= MaxPlayers || players[currentPlayerIndex] == null)
                currentPlayerIndex = 0;
        }
    }
}
