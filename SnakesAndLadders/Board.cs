using System;
using System.Collections.Generic;

namespace SnakesAndLadders
{
    public class Board
    {
        private const int NO_OF_FIELDS = 100;

        public List<bool> Fields { get; set; }

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
            Fields = new List<bool>();
            for (int i = 1; i <= noOfField; i++)
            {
                Fields.Add(true);
            }
        }
    }
}
