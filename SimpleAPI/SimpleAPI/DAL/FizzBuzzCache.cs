using System.Xml;

namespace SimpleAPI.DAL
{
    public class FizzBuzzCache
    {
        public Dictionary<Guid, string> fizzBuzzStore = new Dictionary<Guid, string>();

        public Dictionary<Guid, string> Add(string fizzBuzz, Guid uniqueID)
        {
            var canAdd = fizzBuzzStore.TryAdd(uniqueID, fizzBuzz);
            if (!canAdd)
            {
                fizzBuzzStore[uniqueID] = fizzBuzz;
            }
            return fizzBuzzStore;
        }

        public string GetFizzBuzz(Guid uniqueId)
        {
            var result = fizzBuzzStore.TryGetValue(uniqueId, out var fizzBuzzResult);
            if (result)
            {
                return fizzBuzzResult;
            }
            Console.WriteLine("Returning blank");
            return "";
        }
        //add delete

    }

}
