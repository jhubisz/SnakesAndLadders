using SnakesAndLadders.Enums;
using SnakesAndLadders.Fields;
using SnakesAndLadders.Fields.FieldsConfiguration;
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
        public FieldsConfigurationBase Configuration { get; }

        public PlayerCollection playerCollection;
        public Player CurrentTurnPlayer
        {
            get => playerCollection.CurrentPlayer;
        }

        public Board(IDice dice, FieldsConfiguration configuration)
            : this(NO_OF_FIELDS, MAX_PLAYERS, dice, configuration)
        {
        }
        public Board(int noOfField, int maxPlayers, IDice dice, FieldsConfigurationBase configuration)
        {
            MaxPlayers = maxPlayers;
            Dice = dice;
            Configuration = configuration;
            playerCollection = new PlayerCollection(maxPlayers);

            InitializeBoard(noOfField);
        }

        private void InitializeBoard(int noOfField)
        {
            var fieldsFactory = new FieldsFactory();
            Fields = new List<IField>();
            for (int i = 1; i <= noOfField; i++)
            {
                var fieldFromConfig = Configuration.CheckField(i);
                if (fieldFromConfig != default)
                    AddField(fieldsFactory, fieldFromConfig.fieldNumber, fieldFromConfig.type, fieldFromConfig.targetFieldNumber);
                else
                    AddField(fieldsFactory, i, FieldType.Regular);
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
        public void AddField(FieldsFactory factory, int fieldNumber, FieldType type, int targetFieldNumber = 0)
        {
            var existingField = GetField(fieldNumber);
            if (existingField != default) return;

            IField targetField = null;
            if (targetFieldNumber > 0)
            {
                targetField = GetField(targetFieldNumber);
                if (targetField == default)
                {
                    targetField = factory.CreateField(FieldType.Regular, targetFieldNumber, null);
                    Fields.Add(targetField);
                }
            }

            var field = factory.CreateField(type, fieldNumber, targetField);
            Fields.Add(field);
        }

        public void MovePlayer()
        {
            var diceRoll = Dice.RollTheDice();
            var targetFieldNumber = Players[CurrentTurnPlayer].FieldNumber + diceRoll;
            var targetField = GetField(targetFieldNumber);

            Players[CurrentTurnPlayer] = targetField.ValidateOutcome();
            playerCollection.NextPlayer();
        }
    }
}
