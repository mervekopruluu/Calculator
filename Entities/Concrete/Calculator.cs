using Entities.Abstract;
using Entities.Concrete.Enums;

namespace Entities.Concrete
{
    public partial class Calculator : BaseEntity, IEntity
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public int Outcome { get; set; }
    }
}
