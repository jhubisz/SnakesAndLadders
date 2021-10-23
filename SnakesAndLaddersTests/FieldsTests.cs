using SnakesAndLadders.Fields;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class FieldsTests
    {
        [Fact]
        public void FieldIsOfTypeIField()
        {
            var field = new EmptyField(0);

            Assert.IsAssignableFrom<IField>(field);
        }

        [Fact]
        public void FieldHasNumberIdentifierSpecifiedInConstructor()
        {
            const int FIELD_NUMBER = 1;

            var field = new EmptyField(FIELD_NUMBER);

            Assert.Equal(FIELD_NUMBER, field.FieldNumber);
        }
    }
}
