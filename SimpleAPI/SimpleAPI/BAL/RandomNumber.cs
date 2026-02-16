namespace SimpleAPI.BAL
{
    public class RandomNumber
    {
        private readonly Random _instance = new Random();

        public int Get()
        {
            return _instance.Next(1, 100);
        }
    }
}
