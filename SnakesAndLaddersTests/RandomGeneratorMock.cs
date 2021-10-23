using SnakesAndLadders.Interfaces;

namespace SnakesAndLaddersTests
{
    class RandomGeneratorMock : IRandomGenerator
    {
        private int[] returnNumbers;
        private int index;

        public RandomGeneratorMock(int[] returnNumbersList)
        {
            returnNumbers = returnNumbersList;
        }

        public int Next(int length)
        {
            var currentNumber = returnNumbers[index];
            index = ++index >= returnNumbers.Length ? 0 : index;

            return currentNumber > length ? length : currentNumber;
        }
    }
}
