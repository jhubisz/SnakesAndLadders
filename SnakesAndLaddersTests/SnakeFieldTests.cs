using SnakesAndLadders.Fields;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class SnakeFieldTests
    {
        [Fact]
        public void FieldReturnsValidTargetOutcome()
        {
            IField targetField = new EmptyField(1);
            IField field = new SnakeField(99, targetField);

            var returnedTarget = field.ValidateOutcome();

            Assert.Equal(targetField, returnedTarget);
        }
    }
}
