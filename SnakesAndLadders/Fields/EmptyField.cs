using System;
using System.Collections.Generic;
using System.Text;

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
