using Microsoft.AspNetCore.Mvc;
using SimpleAPI.BAL;
using SimpleAPI.DAL;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //data access layer?
    public class NumberValidationController : ControllerBase
    {
        private readonly IFizzBuzz _numberValidateService;
        private readonly RandomNumber _randomNumber;
        private readonly FizzBuzzCache _fizzBuzzCache;

        //GUID

        public NumberValidationController(IFizzBuzz numberValidateService, RandomNumber randomNumber, FizzBuzzCache fizzBuzzCache)
        {
            _numberValidateService = numberValidateService;
            _fizzBuzzCache = fizzBuzzCache;
            _randomNumber = randomNumber;
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

            Guid uID = string.IsNullOrEmpty(uniqueID) ? Guid.NewGuid() : Guid.Parse(uniqueID);

            if(_fizzBuzzCache.GetFizzBuzz(uID) == "FizzBuzz")
            {
                //this if is breaking the same value being entered; after the first instance of the 
                // UID being entered, it'll save to all future entries..
                return Ok(new
                {
                    uniqueID = uID,
                    fizzBuzz = _fizzBuzzCache.GetFizzBuzz(uID)
                });
            }
            //below code is for new FizzBuzz requests
            var result = _numberValidateService.DoFizzBuzz(request, uID);
            _fizzBuzzCache.Add(result.FizzBuzz, uID);
            
            if (result.FizzBuzz is not "FizzBuzz")
            {
                return BadRequest("Input is not valid");
            }

            return Ok(new { 
                uniqueID = result.UniqueID,
                fizzBuzz = result.FizzBuzz
            });
        }
    }
}

