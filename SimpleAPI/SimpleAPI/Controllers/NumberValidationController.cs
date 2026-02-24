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
            string[] fizzBuzzArray = _fizzBuzzCache.getFizzBuzzArray();
            if (fizzBuzzArray == null)
            {
                fizzBuzzArray = [];
            }
            //if(existingGuid != Guid.Empty)
            //{
            //    return Ok(new
            //    {
            //        uniqueID = existingGuid,
            //        fizzBuzz = "Fizzbuzz"
            //    });
            //}
            //Guid uID = Guid.NewGuid();
            //below code is for new FizzBuzz requests
            //Changing how FizzBuzz Works keeping this in
            //var result = _numberValidateService.DoFizzBuzz(request, uID);


            // Below *Would be* logic to check if fizzBuzz had already been completed for the
            // input number
            //if(_fizzBuzzCache.CheckIfFizzBuzzAlreadyInArray(request))
            //{
            //    return Ok(new
            //    {
            //        uniqueID = fizzBuzzArray,
            //        fizzBuzz = "fizzBuzzArray"
            //    });
            //}

            var result = _numberValidateService.DoFizzBuzzLogic(request);
            fizzBuzzArray = _fizzBuzzCache.setIndexOfFizzBuzz(request, result);

            return Ok(new
            {
                fizzBuzzArray = fizzBuzzArray,
                fizzBuzz = "fizzBuzzArray"
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

