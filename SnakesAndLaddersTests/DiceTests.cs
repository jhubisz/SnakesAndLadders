using SnakesAndLadders;
using SnakesAndLadders.Interfaces;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class DiceTests
    {
        private const int DICE_NUMBER_OF_SIDES = 6;
        [Fact]
        public void DiceIsCreatedAndOfTypeIDice()
        {
            var randomGenerator = new RandomGeneratorMock(new int[] { 1 });
            var dice = new Dice(DICE_NUMBER_OF_SIDES, randomGenerator);

            Assert.IsAssignableFrom<IDice>(dice);
        }

        [Fact]
        public void DiceReturnsThrowBasedOnRandomGenerator()
        {
            var randomThrows = new int[] { 1, 5, 6, 3, 2, 1, 1 };
            var randomGenerator = new RandomGeneratorMock(randomThrows);
            var dice = new Dice(DICE_NUMBER_OF_SIDES, randomGenerator);

            foreach (int t in randomThrows)
            {
                var rollValue = dice.RollTheDice();
                Assert.Equal(t, rollValue);
            }
        }

        [Fact]
        public void DiceReturnsOnlyRandomValuesBetweenOneAndNumberOfSides()
        {
            var iterations = 10000;
            var randomGenerator = new RandomGenerator();
            var dice = new Dice(DICE_NUMBER_OF_SIDES, randomGenerator);

            for (int i = 0; i < iterations; i++)
            {
                var rollValue = dice.RollTheDice();
                Assert.True(rollValue >= 1 && rollValue <= DICE_NUMBER_OF_SIDES);
            }
        }
    }
}
