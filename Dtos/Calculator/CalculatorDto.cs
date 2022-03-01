using Dtos.Enums;

namespace Dtos.Calculator
{
    public class CalculatorDto
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public PublicOperationTypeEnum OperationType { get; set; }
        public string OperationTypeDisplay { get; set; }
        public int Outcome { get; set; }
    }
}
