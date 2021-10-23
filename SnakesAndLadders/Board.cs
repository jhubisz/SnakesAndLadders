using SnakesAndLadders.Fields;
using SnakesAndLadders.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders
{
    public class Board
    {
        private const int NO_OF_FIELDS = 100;
        private const int STARTING_FIELD = 1;

        public List<IField> Fields { get; set; }
        public Dictionary<Player, IField> Players { get; set; }
        public IDice Dice { get; }
        public Player currentTurnPlayer;
        public Player CurrentTurnPlayer
        {
            get
            {
                if (currentTurnPlayer == null)
                    currentTurnPlayer = Players.First().Key;

                return currentTurnPlayer;
            }
        }

        public Board(IDice dice)
            : this(NO_OF_FIELDS, dice)
        {
        }
        public Board(int noOfField, IDice dice)
        {
            InitializeBoard(noOfField);
            Dice = dice;
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
        }
    }
}
