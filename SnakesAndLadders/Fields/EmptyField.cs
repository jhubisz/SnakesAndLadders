using System;

namespace SnakesAndLadders.Fields
{
    public class EmptyField : IField
    {
        public int FieldNumber { get; private set; }

        public EmptyField(int fieldNumber)
        {
            FieldNumber = fieldNumber;
        }

        public bool ValidateOutcome()
        {
            throw new NotImplementedException();
        }
    }
}
