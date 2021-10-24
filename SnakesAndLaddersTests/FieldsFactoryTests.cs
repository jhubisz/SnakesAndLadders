using SnakesAndLadders.Enums;
using SnakesAndLadders.Fields;
using Xunit;

namespace SnakesAndLaddersTests
{
    public class FieldsFactoryTests
    {
        public FieldsFactory FieldsFactory { get; set; }

        public FieldsFactoryTests()
        {
            FieldsFactory = new FieldsFactory();
        }

        [Fact]
        public void CreatesEmptyFields()
        {
            var fieldNumber = 1;
            var field = FieldsFactory.CreateField(FieldType.Regular, fieldNumber, null);

            Assert.IsAssignableFrom<EmptyField>(field);
            Assert.Equal(fieldNumber, field.FieldNumber);
        }

        [Fact]
        public void CreatesSnakeFields()
        {
            var fieldNumber = 10;
            var targetFieldNumber = 5;
            var targetField = FieldsFactory.CreateField(FieldType.Regular, targetFieldNumber, null);
            var field = FieldsFactory.CreateField(FieldType.Snake, fieldNumber, targetField);

            Assert.IsAssignableFrom<SnakeField>(field);
            Assert.Equal(fieldNumber, ((SnakeField)field).FieldNumber);
            Assert.Equal(targetFieldNumber, ((SnakeField)field).TransferToField.FieldNumber);
        }

        [Fact]
        public void CreatesLadderFields()
        {
            var fieldNumber = 10;
            var targetFieldNumber = 50;
            var targetField = FieldsFactory.CreateField(FieldType.Regular, targetFieldNumber, null);
            var field = FieldsFactory.CreateField(FieldType.Ladder, fieldNumber, targetField);

            Assert.IsAssignableFrom<LadderField>(field);
            Assert.Equal(fieldNumber, ((LadderField)field).FieldNumber);
            Assert.Equal(targetFieldNumber, ((LadderField)field).TransferToField.FieldNumber);
        }
    }
}
