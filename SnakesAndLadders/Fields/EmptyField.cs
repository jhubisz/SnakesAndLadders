using System;

namespace SnakesAndLadders.Fields
{
    public class EmptyField : IField
    {
        public bool ValidateOutcome()
        {
            throw new NotImplementedException();
        }
    }
}
