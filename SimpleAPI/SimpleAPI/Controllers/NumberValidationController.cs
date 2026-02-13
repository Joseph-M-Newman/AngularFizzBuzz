using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //data access layer?
    public class NumberValidationController : ControllerBase
    {

        private readonly INumberValidate _numberValidateService;

        private int getRandomNumber()
        {
            Random randomNumber = new Random();
            return randomNumber.Next(1, 100);
        }

        public NumberValidationController(INumberValidate numberValidateService)
        {
            _numberValidateService = numberValidateService;
        }

        [HttpGet("getrandomnumber")]
        public IActionResult GetById(int id)
        {
            int returnRandom = getRandomNumber();
            return Ok(returnRandom);
        }

        [HttpPost]
        public IActionResult validateFizzBuzz([FromBody] NumberValidation request)
        {
            var result = _numberValidateService.ValidateNumber(request.inputNumber);

            return Ok(new NumberValidation
            {
                inputNumber = request.inputNumber,
                Result = result
            });
        }
    }
}

