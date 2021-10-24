using SnakesAndLadders.Enums;

namespace SnakesAndLadders.Fields
{
    public interface IField
    {
        int FieldNumber { get; }
        FieldType FieldType { get; }

        IField ValidateOutcome();
    }
}
