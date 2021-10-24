using System;
using System.Runtime.Serialization;

namespace SnakesAndLadders.Exceptions
{
    public class NumberOfPlayersExceededException : Exception
    {
        public NumberOfPlayersExceededException()
        {
        }

        public NumberOfPlayersExceededException(string message) : base(message)
        {
        }

        public NumberOfPlayersExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NumberOfPlayersExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
