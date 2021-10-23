using SnakesAndLadders.Interfaces;
using System;

namespace SnakesAndLadders
{
    public class RandomGenerator : IRandomGenerator
    {
        private Random Random { get; set; }

        public RandomGenerator()
        {
            Random = new Random();
        }

        public int Next(int length)
        {
            return Random.Next(1, length);
        }
    }
}
