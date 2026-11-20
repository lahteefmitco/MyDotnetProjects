using ERPSample.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try{
            if(id <= 0)
            {
               throw new ArgumentException("ID must be a positive integer.");
            }

            return Ok($"Hello from SampleController with ID: {id}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(StatusCodes.Status500InternalServerError, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<string[]> GetAll()
        {
            try
            {
                // Simulate fetching data from a database or service
                var data = new List<string> { "Item1", "Item2", "Item3" };

                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(StatusCodes.Status500InternalServerError, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpGet("by-id")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<string> GetById([FromQuery] int id, [FromQuery] string name)
        {
            try
            {
                //throw new Exception("This is a test exception for demonstration purposes.");
                if (id <= 0)
                {
                    throw new ArgumentException("ID must be a positive integer.");
                }

                // Simulate fetching data from a database or service
                var data = $"Data for ID: {id}, Name: {name}";

                return Ok(data);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(StatusCodes.Status500InternalServerError, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpPost("insert")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult<SampleResponse> SamplePostRequest([FromBody] SampleRequestBody sampleRequestBody)
        {
            var response = new SampleResponse
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK
            };

            return Ok(response);
        }
    }
}
