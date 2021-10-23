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
            var dice = new Dice();

            Assert.IsAssignableFrom<IDice>(dice);
        }
    }
}
