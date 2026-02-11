using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberValidationController : ControllerBase
    {
        private static readonly int[] Summaries = new[]
        {
           043, 067, 100, 198, 212, 343
        };

        private readonly ILogger<NumberValidationController> _logger;

        public NumberValidationController(ILogger<NumberValidationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetNumberValidation")]
        public IEnumerable<NumberValidation> Get()
        {
            return Enumerable.Range(1, 3).Select(index => new NumberValidation
            {
                ID = Summaries[Random.Shared.Next(Summaries.Length)],
                FizzBuzz = "FizzBuzz"
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var apiGeneration = Get();
            var allIDs = apiGeneration.FirstOrDefault(x => x.ID == id);
            return Ok(allIDs);
        }
    }
}

