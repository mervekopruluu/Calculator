using Business.Abstract;
using DataAccess.Abstract;
using Dtos.Calculator;
using Entities.Concrete;
using Entities.Concrete.Enums;
using Entities.Result;
using EnumsNET;
using Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Html;

namespace Business.Concrete
{
    public class CalculatorManager : ICalculatorService
    {
        private readonly ICalculatorDal _calculatorDal;
        private readonly ICalculatorSoapService _calculatorSoapService;
        public CalculatorManager(
            ICalculatorDal calculatorDal,
            ICalculatorSoapService calculatorSoapService)
        {
            _calculatorDal = calculatorDal;
            _calculatorSoapService = calculatorSoapService;
        }

        public Result Add(CalculatorDto calculator)
        {
            try
            {
                _calculatorDal.Add(new Calculator
                {
                    Outcome = calculator.Outcome,
                    Number1 = calculator.Number1,
                    OperationType = (OperationTypeEnum)calculator.OperationType,
                    Number2 = calculator.Number2
                });
                return new Result
                {
                    Message = "Success",
                    Status = true
                };
            }
            catch (Exception ex)
            {
                return new Result
                {
                    Message = ex.Message,
                    Status = false
                };
            }
        }

        public async Task<Result> Calculate(CalculatorDto input)
        {
            int returnData;
            switch (input.OperationType)
            {
                case OperationTypeEnum.add:
                    returnData = await _calculatorSoapService.AddAsync(input.Number1, input.Number2);
                    break;
                case OperationTypeEnum.subtract:
                    returnData = await _calculatorSoapService.SubtractAsync(input.Number1, input.Number2);
                    break;
                case OperationTypeEnum.divide:
                    returnData = await _calculatorSoapService.DivideAsync(input.Number1, input.Number2);
                    break;
                case OperationTypeEnum.multiply:
                    returnData = await _calculatorSoapService.MultiplyAsync(input.Number1, input.Number2);
                    break;
                default:
                    return new Result
                    {
                        Message = "Error",
                        Status = false,
                    };
            }

            return new Result
            {
                Message = "Success",
                ReturnData = returnData,
                Status = true
            };
        }

        public List<CalculatorDto> GetAll()
        {
            return _calculatorDal.GetAll().Select(x => new CalculatorDto
            {
                Number1 = x.Number1,
                Number2 = x.Number2,
                OperationType = (OperationTypeEnum)x.OperationType,
                OperationTypeDisplay = ((OperationTypeEnum)x.OperationType).AsString(EnumFormat.Description),
                Outcome = x.Outcome
            }).ToList();
        }
    }
}
