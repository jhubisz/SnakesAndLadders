using SnakesAndLadders.Interfaces;

namespace SnakesAndLadders
{
    public class Dice : IDice
    {
        public IRandomGenerator RandomGenerator { get; }

        public Dice(IRandomGenerator randomGenerator)
        {
            RandomGenerator = randomGenerator;
        }

        public int RollTheDice()
        {
            return 1;
        }
    }
}
