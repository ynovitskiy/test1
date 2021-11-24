using System.Threading.Tasks;
using Company.Api.Logic.Core;
using Company.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IMeasureService _calculateService;

        public DistanceController(IMeasureService calculateService)
        {
            _calculateService = calculateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDistanceAsync([FromQuery]DistanceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not correct");
            }

            var distance = await _calculateService.CalculateDistance(request.From, request.To);
            return Ok(distance);
        }
    }
}
