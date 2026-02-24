namespace SimpleAPI.Core.Models
{
    public class FizzBuzzResponse
    {
        public FizzBuzzResponse()
        {
        }

        public FizzBuzzResponse(int index, string fizzBuzzArray)
        {
            fizzBuzzArrayIndex = index;
            FizzBuzzLogicResult = fizzBuzzArray;
        }
        //public Guid UniqueID { get; set; }
        //public string FizzBuzz { get; set; }

        public int fizzBuzzArrayIndex { get; set; }
        public string FizzBuzzLogicResult {  get; set; }

    }
}
