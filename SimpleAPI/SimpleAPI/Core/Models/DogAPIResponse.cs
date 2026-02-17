using System.Text.Json.Nodes;

namespace SimpleAPI.Core.Models
{
    public class DogAPIResponse
    {
        public DogAPIResponse(string breedID, string dogBreed, int lifeMin, 
            int lifeMax, int maleWeightMin, int maleWeightMax, int femaleWeightMin, 
            int femaleWeightMax, string dogBreedDescription)
        {
            id = breedID;
            DogBreed = dogBreed;
            LifeMin = lifeMin;
            LifeMax = lifeMax;
            MaleWeightMin = maleWeightMin;
            MaleWeightMax = maleWeightMax;
            FemaleWeightMin = femaleWeightMin;
            FemaleWeightMax = femaleWeightMax;
            DogBreedDescription = dogBreedDescription;
        }
        public string id { get; set; }
        public string DogBreed { get; set; }

        public int LifeMin { get; set; }
        public int LifeMax { get; set; }
        public int MaleWeightMin { get; set; }
        public int MaleWeightMax { get; set; }
        public int FemaleWeightMin { get; set; }
        public int FemaleWeightMax { get; set; }
        public string DogBreedDescription { get; set; }
    }
}
