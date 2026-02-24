using SimpleAPI.Core.Models;
using SimpleAPI.DAL;
using System.Text;

namespace SimpleAPI.Services
{
    public class FizzBuzz : IFizzBuzz
    {
        public FizzBuzz(FizzBuzzCache fizzBuzzCache)
        {
        }
        //Example function DoFizzBuzz
        public string ValidateNumber(int number)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (number >= 1 && number <= 100)
            {
                stringBuilder.Append("FizzBuzz");
                return stringBuilder.ToString();
            }
            stringBuilder.Append("Number not between 1-100");
            return stringBuilder.ToString();
        }
        public FizzBuzzResponse DoFizzBuzz(int request, string uniqueID)
        {
            // Do my FizzBuzz algorithm logic here
            //if(request < 1 || request > 100)
            //{
            //    return new FizzBuzzResponse();
            //}
            // Use string builder when working with strings
            StringBuilder fizzBuzzStringBuilder = new StringBuilder("FizzBuzz");
            // Generate GUID is it doesnt exist; If it does return GUID
            //return  new FizzBuzzResponse(fizzBuzzStringBuilder.ToString(), Guid.NewGuid());
            return new FizzBuzzResponse(request, Guid.NewGuid().ToString());
        }
        public string DoFizzBuzzLogic(int index)
        {
            StringBuilder fizzBuzzStringBuilder = new StringBuilder();

            if (index % 3 == 0 && index % 5 == 0)
            {
                fizzBuzzStringBuilder.Append("FizzBuzz");
            }
            else if (index % 5 == 0)
            {
                fizzBuzzStringBuilder.Append("Buzz");
            }
            else if (index % 3 == 0)
            {
                fizzBuzzStringBuilder.Append("Fizz");
            }
            else
            {
                fizzBuzzStringBuilder.Append(index.ToString());
            }
            Console.WriteLine(fizzBuzzStringBuilder.ToString());
            return fizzBuzzStringBuilder.ToString();
        }
    }
}
