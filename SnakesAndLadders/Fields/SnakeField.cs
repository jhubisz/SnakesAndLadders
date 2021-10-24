using SnakesAndLadders.Enums;

namespace SnakesAndLadders.Fields
{
    public class SnakeField : IField
    {
        public int FieldNumber { get; private set; }

        public FieldType FieldType { get; private set; }

        public IField TransferToField { get; private set; }

        public SnakeField(int fieldNumber, IField transferToField)
        {
            FieldType = FieldType.Snake;
            FieldNumber = fieldNumber;
            TransferToField = transferToField;
        }

        public IField ValidateOutcome()
        {
            return TransferToField;
        }
    }
}
