using SnakesAndLadders.Enums;

namespace SnakesAndLadders.Fields
{
    public class LadderField : IField
    {
        public int FieldNumber { get; private set; }

        public FieldType FieldType { get; private set; }

        public IField TransferToField { get; private set; }

        public LadderField(int fieldNumber, IField transferToField)
        {
            FieldType = FieldType.Ladder;
            FieldNumber = fieldNumber;
            TransferToField = transferToField;
        }

        public IField ValidateOutcome()
        {
            return TransferToField;
        }
    }
}
