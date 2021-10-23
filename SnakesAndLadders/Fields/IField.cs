namespace SnakesAndLadders.Fields
{
    public interface IField
    {
        int FieldNumber { get; }
        bool ValidateOutcome();
    }
}
