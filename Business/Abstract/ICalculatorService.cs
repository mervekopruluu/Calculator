using Dtos.Calculator;
using Dtos.Result;
using Entities.Concrete.Enums;
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
