using System.Threading.Tasks;

namespace Infrastructure.Abstract
{
    public interface ICalculatorSoapService 
    {
        Task<int> AddAsync(int intA, int intB);
        Task<int> SubtractAsync(int intA, int intB);
        Task<int> DivideAsync(int intA, int intB);
        Task<int> MultiplyAsync(int intA, int intB);
    }
}
