using System.Text;
using System.Xml;

namespace SimpleAPI.DAL
{
    public class FizzBuzzCache
    {
        public Dictionary<int, Guid> fizzBuzzStore = new Dictionary<int, Guid>();
        public string[] fizzBuzzArray = new string[99];
        public Dictionary<int, Guid> Add(int numberInput, Guid uniqueID)
        {
            Console.WriteLine("Attempting to Add to the dictionary");
            var canAdd = fizzBuzzStore.TryAdd(numberInput, uniqueID);
            Console.WriteLine("Current dictionary count: " + fizzBuzzStore.Count);
            if (!canAdd)
            {
                fizzBuzzStore[numberInput] = uniqueID;
            }
            return fizzBuzzStore;
        }

        public Guid GetFizzBuzz(int numberInput)
        {
            var result = fizzBuzzStore.TryGetValue(numberInput, out var fizzBuzzResult);
            if (result)
            {
                return fizzBuzzResult;
            }
            return Guid.Empty;
        }

        public string DeleteFizzBuzzEntry(int numberInput)
        {
            var result = fizzBuzzStore.Remove(numberInput);
            if(result)
            {
                return "Entry deleted";
            }
            return "Unable to delete entry";
        }

        public string[] getFizzBuzzArray()
        {
            return fizzBuzzArray;
        }

        public string[] setIndexOfFizzBuzz(int index, string result)
        {
            StringBuilder sb = new StringBuilder();
            fizzBuzzArray[index] = result;
            sb.Append($"{result} added to fizzBuzzArray[{index}]");
            return fizzBuzzArray;
        }

        public Boolean CheckIfFizzBuzzAlreadyInArray(int index)
        {
            if (fizzBuzzArray[index] == null)
            {
                return false;
            }
            return true;
        }
    }

}
