namespace SimpleAPI.Core.Models
{
    public class FizzBuzzResponse
    {
        public FizzBuzzResponse()
        {
        }

        public FizzBuzzResponse(string fizzBuzz, Guid uniqueID)
        {
            UniqueID = uniqueID;
            FizzBuzz = fizzBuzz;
        }
        public Guid UniqueID { get; set; }
        public string FizzBuzz { get; set; }

    }
}
