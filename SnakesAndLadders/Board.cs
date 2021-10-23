﻿using SnakesAndLadders.Fields;
using System;
using System.Collections.Generic;

namespace SnakesAndLadders
{
    public class Board
    {
        private const int NO_OF_FIELDS = 100;

        public List<IField> Fields { get; set; }
        public List<Player> Players { get; set; }

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
                Players = new List<Player>();

            Players.Add(player);
        }
    }
}
