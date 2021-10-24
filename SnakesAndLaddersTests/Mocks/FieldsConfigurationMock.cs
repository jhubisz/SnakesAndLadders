using SnakesAndLadders.Enums;
using SnakesAndLadders.Fields.FieldsConfiguration;

namespace SnakesAndLaddersTests.Mocks
{
    class FieldsConfigurationMock : FieldsConfigurationBase
    {
        public override void BuildFieldsCollection()
        {
            FieldsCollection.Add((10, FieldType.Ladder, 99));
            FieldsCollection.Add((20, FieldType.Ladder, 30));

            FieldsCollection.Add((12, FieldType.Snake, 2));
            FieldsCollection.Add((50, FieldType.Snake, 40));
        }
    }
}
