using SnakesAndLadders.Fields;
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

        public Board()
            : this(NO_OF_FIELDS)
        {
        }
        public Board(int noOfField)
        {
            InitializeBoard(noOfField);
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
    }
}
