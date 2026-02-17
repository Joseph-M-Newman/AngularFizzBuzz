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
            Guid uID =  Guid.NewGuid();
            var existingGuid = _fizzBuzzCache.GetFizzBuzz(request);
            if(existingGuid != Guid.Empty)
            {
                return Ok(new
                {
                    uniqueID = existingGuid,
                    fizzBuzz = "Fizzbuzz"
                });
            }
            //below code is for new FizzBuzz requests
            var result = _numberValidateService.DoFizzBuzz(request, uID);
            _fizzBuzzCache.Add(request, uID);

            return Ok(new { 
                uniqueID = result.UniqueID,
                fizzBuzz = "FizzBuzz"
            });
        }
    }
}

