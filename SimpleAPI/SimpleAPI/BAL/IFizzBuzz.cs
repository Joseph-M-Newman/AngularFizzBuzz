using SimpleAPI.Core.Models;

namespace SimpleAPI.Services
{
    //This is my BAL Interface
    public interface IFizzBuzz
    {
        string ValidateNumber(int number);
        FizzBuzzResponse DoFizzBuzz(int number, Guid uniqueID);
    }
}
