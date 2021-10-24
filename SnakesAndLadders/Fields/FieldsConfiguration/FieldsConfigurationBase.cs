using SnakesAndLadders.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders.Fields.FieldsConfiguration
{
    public abstract class FieldsConfigurationBase
    {
        public List<(int fieldNumber, FieldType fieldType, int targetFieldNumber)> FieldsCollection;

        public FieldsConfigurationBase()
        {
            FieldsCollection = new List<(int fieldNumber, FieldType fieldType, int targetFieldNumber)>();
            BuildFieldsCollection();
        }

        public abstract void BuildFieldsCollection();

        public (int fieldNumber, FieldType type, int targetFieldNumber) CheckField(int fieldNumber)
        {
            return FieldsCollection.FirstOrDefault(f => f.fieldNumber == fieldNumber);
        }
    }
}
