using System.ComponentModel;

namespace Entities.Concrete.Enums
{
    public enum OperationTypeEnum
    {
        [Description("Toplama")]
        add = 1,
        [Description("Çıkarma")]
        subtract,
        [Description("Bölme")]
        divide,
        [Description("Çarpma")]
        multiply,
    }
}
