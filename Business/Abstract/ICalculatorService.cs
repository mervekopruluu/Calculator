using Dtos.Calculator;
using Entities.Concrete.Enums;
using Entities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICalculatorService
    {
        List<CalculatorDto> GetAll();
        Result Add(CalculatorDto calculator);
        Task<Result> Calculate(CalculatorDto input);
    }
}
