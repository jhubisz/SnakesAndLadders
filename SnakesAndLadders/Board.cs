using SnakesAndLadders.Fields;
using SnakesAndLadders.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders
{
    public class Board
    {
        private const int NO_OF_FIELDS = 100;
        private const int MAX_PLAYERS = 10;
        private const int STARTING_FIELD = 1;
        
        public int MaxPlayers { get; }
        public List<IField> Fields { get; set; }
        public Dictionary<Player, IField> Players { get; set; }
        public IDice Dice { get; }

        public PlayerCollection playerCollection;
        public Player CurrentTurnPlayer
        {
            get => playerCollection.CurrentPlayer;
        }

        public Board(IDice dice)
            : this(NO_OF_FIELDS, MAX_PLAYERS, dice)
        {
        }
        public Board(int noOfField, int maxPlayers, IDice dice)
        {
            InitializeBoard(noOfField);
            MaxPlayers = maxPlayers;
            Dice = dice;

            playerCollection = new PlayerCollection(maxPlayers);
        }

        private void InitializeBoard(int noOfField)
        {
            Fields = new List<IField>();
            for (int i = 1; i <= noOfField; i++)
            {
                Fields.Add(new EmptyField(i));
            }
        }

        public void AddPlayer(Player player)
        {
            if (Players == null)
                Players = new Dictionary<Player, IField>();

            Players.Add(player, GetField(STARTING_FIELD));
            playerCollection.Add(player);
        }

        public IField GetField(int fieldNo)
        {
            return Fields.FirstOrDefault(i => i.FieldNumber == fieldNo);
        }

        public void MovePlayer()
        {
            var diceRoll = Dice.RollTheDice();
            var targetFieldNumber = Players[CurrentTurnPlayer].FieldNumber + diceRoll;
            var targetField = GetField(targetFieldNumber);

            Players[CurrentTurnPlayer] = targetField;
            playerCollection.NextPlayer();
        }
    }
}
