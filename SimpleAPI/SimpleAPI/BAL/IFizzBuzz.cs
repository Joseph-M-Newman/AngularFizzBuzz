using SimpleAPI.Core.Models;

namespace SimpleAPI.Services
{
    //This is my BAL Interface
    public interface IFizzBuzz
    {
        string ValidateNumber(int number);
        FizzBuzzResponse DoFizzBuzz(int index, string FizzBuzzLogicResult);

        string DoFizzBuzzLogic(int index);

    }
}
