using SnakesAndLadders.Enums;
using SnakesAndLadders.Exceptions;

namespace SnakesAndLadders.Fields
{
    public class FieldsFactory
    {
        public IField CreateField(FieldType type, int fieldNumber, IField targetField)
        {
            switch (type)
            {
                case FieldType.Regular:
                    return CreateRegularField(fieldNumber);
                case FieldType.Ladder:
                    return CreateLadderField(fieldNumber, targetField);
                case FieldType.Snake:
                    return CreateSnakeField(fieldNumber, targetField);
                default:
                    throw new UnknownFieldTypeException();
            }
        }

        public IField CreateRegularField(int fieldNumber)
        {
            return new EmptyField(fieldNumber);
        }

        public IField CreateSnakeField(int fieldNumber, IField targetField)
        {
            return new SnakeField(fieldNumber, targetField);
        }

        public IField CreateLadderField(int fieldNumber, IField targetField)
        {
            return new LadderField(fieldNumber, targetField);
        }
    }
}
