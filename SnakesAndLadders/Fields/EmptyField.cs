using SnakesAndLadders.Enums;

namespace SnakesAndLadders.Fields
{
    public class EmptyField : IField
    {
        public int FieldNumber { get; private set; }
        public FieldType FieldType { get; private set; }

        public EmptyField(int fieldNumber)
        {
            FieldType = FieldType.Regular;
            FieldNumber = fieldNumber;
        }

        public IField ValidateOutcome()
        {
            return this;
        }
    }
}
