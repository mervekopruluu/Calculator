using System.ComponentModel;

namespace Dtos.Enums
{
    public enum PublicOperationTypeEnum
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
