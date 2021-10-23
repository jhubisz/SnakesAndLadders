using System;

namespace SnakesAndLadders.Fields
{
    public class EmptyField : IField
    {
        public int FieldNumber { get; private set; }

        public bool ValidateOutcome()
        {
            throw new NotImplementedException();
        }
    }
}
