using SnakesAndLadders.Enums;

namespace SnakesAndLadders.Fields.FieldsConfiguration
{
    public class FieldsConfiguration : FieldsConfigurationBase
    {
        public override void BuildFieldsCollection()
        {
            FieldsCollection.Add((10, FieldType.Ladder, 25));
            FieldsCollection.Add((17, FieldType.Ladder, 42));
            FieldsCollection.Add((34, FieldType.Ladder, 62));
            FieldsCollection.Add((39, FieldType.Ladder, 82));
            FieldsCollection.Add((60, FieldType.Ladder, 91));

            FieldsCollection.Add((99, FieldType.Snake, 11));
            FieldsCollection.Add((87, FieldType.Snake, 72));
            FieldsCollection.Add((66, FieldType.Snake, 52));
            FieldsCollection.Add((31, FieldType.Snake, 20));
            FieldsCollection.Add((20, FieldType.Snake, 10));
        }
    }
}
