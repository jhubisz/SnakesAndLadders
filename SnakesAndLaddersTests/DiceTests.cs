using SnakesAndLadders;
using SnakesAndLadders.Interfaces;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class DiceTests
    {
        [Fact]
        public void DiceIsCreatedAndOfTypeIDice()
        {
            var randomGenerator = new RandomGeneratorMock(new int[] { 1 });
            var dice = new Dice(randomGenerator);

            Assert.IsAssignableFrom<IDice>(dice);
        }
    }
}
