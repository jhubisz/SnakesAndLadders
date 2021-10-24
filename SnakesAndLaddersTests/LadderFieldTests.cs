using SnakesAndLadders.Fields;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class LadderFieldTests
    {
        [Fact]
        public void FieldReturnsValidTargetOutcome()
        {
            IField targetField = new EmptyField(10);
            IField field = new LadderField(1, targetField);

            var returnedTarget = field.ValidateOutcome();

            Assert.Equal(targetField, returnedTarget);
        }
    }
}
