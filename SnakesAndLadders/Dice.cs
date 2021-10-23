using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders
{
    public class Dice : IDice
    {
        private int NumberOfSides { get; }
        private IRandomGenerator RandomGenerator { get; }

        public Dice(int numberOfSides, IRandomGenerator randomGenerator)
        {
            NumberOfSides = numberOfSides;
            RandomGenerator = randomGenerator;
        }

        public int RollTheDice()
        {
            return RandomGenerator.Next(NumberOfSides);
        }
    }
}
