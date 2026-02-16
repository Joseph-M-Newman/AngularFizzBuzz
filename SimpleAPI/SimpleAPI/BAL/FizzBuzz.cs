using SimpleAPI.Core.Models;
using SimpleAPI.DAL;
using System.Text;

namespace SimpleAPI.Services
{
    public class FizzBuzz : IFizzBuzz
    {
        private readonly FizzBuzzCache _fizzBuzzCache;
        public FizzBuzz(FizzBuzzCache fizzBuzzCache)
        {
            _fizzBuzzCache = fizzBuzzCache;
        }
        //Example function DoFizzBuzz
        public string ValidateNumber(int number)
        {
            if (number >= 1 && number <= 100)
                return "FizzBuzz";

            return "Number not between 1-100";
        }
        public FizzBuzzResponse DoFizzBuzz(int request, Guid uniqueID)
        {
            // Do my FizzBuzz algorithm logic here
            if(request < 1 || request > 100)
            {
                return new FizzBuzzResponse();
            }
            // Use string builder when working with strings
            StringBuilder fizzBuzzStringBuilder = new StringBuilder("FizzBuzz");
            // Generate GUID is it doesnt exist; If it does return GUID
            return uniqueID != Guid.Empty ? new FizzBuzzResponse(fizzBuzzStringBuilder.ToString(), uniqueID) : new FizzBuzzResponse(fizzBuzzStringBuilder.ToString(), Guid.NewGuid());

        }
    }
}
