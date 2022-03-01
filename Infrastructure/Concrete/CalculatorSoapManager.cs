using Infrastructure.Abstract;
using Infrastructure.CalculatorSoapService;
using System.Threading.Tasks;

namespace Infrastructure.Concrete
{
    public class CalculatorSoapManager : ICalculatorSoapService
    {
        private readonly CalculatorSoapClient _calculatorSoapClient;
        public CalculatorSoapManager()
        {
            _calculatorSoapClient = new CalculatorSoapClient();
        }

        public Task<int> AddAsync(int intA, int intB)
        {
            return _calculatorSoapClient.AddAsync(intA, intB);
        }

        public Task<int> DivideAsync(int intA, int intB)
        {
            return _calculatorSoapClient.DivideAsync(intA, intB);
        }

        public Task<int> MultiplyAsync(int intA, int intB)
        {
            return _calculatorSoapClient.MultiplyAsync(intA, intB);
        }

        public Task<int> SubtractAsync(int intA, int intB)
        {
            return _calculatorSoapClient.SubtractAsync(intA, intB);
        }
    }
}
