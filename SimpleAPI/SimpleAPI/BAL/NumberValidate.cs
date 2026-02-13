namespace SimpleAPI.Services
{
    //this is the BAL (Business Access Layer). We won't use a DAL yet. If we want to access a third party API which DOES use a API such as RL API we would make a service(s)
    public class NumberValidate : INumberValidate
    {
        public string ValidateNumber(int number)
        {
            if (number >= 1 && number <= 100)
                return "FizzBuzz";

            return "Number not between 1-100";
        }
    }
}
