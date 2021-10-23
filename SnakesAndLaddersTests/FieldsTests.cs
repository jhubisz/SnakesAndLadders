using SnakesAndLadders.Fields;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class FieldsTests
    {
        [Fact]
        public void FieldIsOfTypeIField()
        {
            var field = new EmptyField();

            Assert.IsAssignableFrom<IField>(field);
        }

        [Fact]
        public void FieldHasNumberIdentifier()
        {
            var field = new EmptyField();

            Assert.Equal(0, field.FieldNumber);
        }
    }
}
