using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PaymentService.DTOs.Test;
using PaymentService.Services.Test;
using System.Text;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ITestService _testService;

        public PaymentController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<string> Test()
        {
            return "payment controller 1";
        }

        [HttpGet("/test")]
        public async Task<ActionResult<List<GetTestDTO>>> Value()
        {
            try
            {
                List<GetTestDTO> response = await _testService.getAllTests();
                if(response == null) return NotFound(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(null);
            }
        }

        //[HttpGet("/prices")]
        //public async Task<ActionResult<List<>>> getPrices()
        //{


        //}





    }
}
