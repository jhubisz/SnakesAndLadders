using System;
using System.Runtime.Serialization;

namespace SnakesAndLadders.Exceptions
{
    class UnknownFieldTypeException : Exception
    {
        public UnknownFieldTypeException()
        {
        }

        public UnknownFieldTypeException(string message) : base(message)
        {
        }

        public UnknownFieldTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownFieldTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
