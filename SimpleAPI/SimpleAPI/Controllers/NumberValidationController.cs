using Microsoft.AspNetCore.Mvc;
using SimpleAPI.BAL;
using SimpleAPI.DAL;
using SimpleAPI.Helpers;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberValidationController : ControllerBase
    {
        private readonly IFizzBuzz _numberValidateService;
        private readonly RandomNumber _randomNumber;
        private readonly FizzBuzzCache _fizzBuzzCache;
        private readonly IDogFactAPI _dogFactAPI;
        private readonly DogBreedIDList _dogBreedIDList;


        public NumberValidationController(IFizzBuzz numberValidateService, RandomNumber randomNumber, FizzBuzzCache fizzBuzzCache, IDogFactAPI dogFactAPI, DogBreedIDList dogBreedIDList)
        {
            _numberValidateService = numberValidateService;
            _fizzBuzzCache = fizzBuzzCache;
            _randomNumber = randomNumber;
            _dogFactAPI = dogFactAPI;
            _dogBreedIDList = dogBreedIDList;
        }

        [HttpGet("getrandomnumber")]
        public IActionResult GetRandomNumber()
        {
            return Ok(_randomNumber.Get());
        }
        //add route here - Best practice for REST 
        [HttpPost("validatefizzbuzz")]
        public IActionResult ValidateFizzBuzz([FromBody] int request, [FromQuery] string? uniqueID = null)
        {
            var existingGuid = _fizzBuzzCache.GetFizzBuzz(request);
            if(existingGuid != Guid.Empty)
            {
                return Ok(new
                {
                    uniqueID = existingGuid,
                    fizzBuzz = "Fizzbuzz"
                });
            }
            Guid uID = Guid.NewGuid();
            //below code is for new FizzBuzz requests
            var result = _numberValidateService.DoFizzBuzz(request, uID);
            _fizzBuzzCache.Add(request, uID);

            return Ok(new { 
                uniqueID = result.UniqueID,
                fizzBuzz = "FizzBuzz"
            });
        }

        [HttpPost("getrandomdogfact")]
        public async Task<IActionResult> GetAPIData([FromBody] int breedID)
        {
            var breedIDToGuid = _dogBreedIDList.getIDDogBreedList(breedID); 
            var result = await _dogFactAPI.GetBreedAsync(breedIDToGuid);
            return Ok(result);
        }
    }
}

