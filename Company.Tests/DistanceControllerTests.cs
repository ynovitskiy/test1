using System.Threading.Tasks;
using Company.Api.Controllers.v1;
using Company.Api.Logic.Core;
using Company.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Company.Api.Tests
{
    public class DistanceControllerTests
    {
        [Fact]
        public async Task GetDistance_ReturnsOkWhenModeIsOk()
        {
            var request = new DistanceRequest { From = "AMS", To = "AMS" };

            var mock = new Mock<IMeasureService>();
            mock.Setup(x => x.CalculateDistance(request.From, request.To))
                .ReturnsAsync(0);

            var controller = new DistanceController(mock.Object);
            
            var result = await controller.GetDistanceAsync(request);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetDistance_ReturnsBadRequestWhenModeIsNotOk()
        {
            var request = new DistanceRequest { From = "", To = ""};

            var mock = new Mock<IMeasureService>();
            mock.Setup(x => x.CalculateDistance(request.From, request.To))
                .ReturnsAsync(0);

            var controller = new DistanceController(mock.Object);
            controller.ModelState.AddModelError("From", "Field From is required");

            var result = await controller.GetDistanceAsync(request);
            Assert.IsType<BadRequestObjectResult>(result);

            var typedResult = (BadRequestObjectResult) result;

            Assert.Equal(typedResult.Value.ToString(), "Model is not correct");
        }
    }
}