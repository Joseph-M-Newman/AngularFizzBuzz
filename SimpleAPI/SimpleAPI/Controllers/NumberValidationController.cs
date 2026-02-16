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
            // TODO: The same GUID is being passed in with every entry; Find the bug
            // thats causing this. Look at FizzBuzzCache and check front end input;
            Guid uID = Guid.Empty;
            if(uniqueID is not null)
            {
                uID = Guid.Parse(uniqueID); 
            }

            if(_fizzBuzzCache.GetFizzBuzz(uID) is "FizzBuzz")
            {
                return Ok(new
                {
                    uniqueID = uID.ToString(),
                    fizzBuzz = _fizzBuzzCache.GetFizzBuzz(uID)
                });
            }

            //below code is for new FizzBuzz requests
            var result = _numberValidateService.DoFizzBuzz(request, uID);
            _fizzBuzzCache.Add(result.FizzBuzz, uID);

            if(result.FizzBuzz is not "FizzBuzz")
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

