using KnockKnock.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace KnockKnock.Tests
{
    public class TestChallengeController
    {
        [Fact]
        public void GetFibonacciNumber_ShouldReturnOk()
        {
            var controller = new ChallengeController();
            var result = controller.GetFibonacciNumber(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetFibonacciNumber_ShouldReturnValue()
        {
            var controller = new ChallengeController();
            var result = controller.GetFibonacciNumber(10);
            var test = result as OkObjectResult;
            Assert.Equal("55", test.Value.ToString());
        }

        [Fact]
        public void GetFibonacciNumber_ShouldReturnBadRequest()
        {
            var controller = new ChallengeController();
            var result = controller.GetFibonacciNumber(93);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetReverseWords_ShouldReturnOk()
        {
            var controller = new ChallengeController();
            var result = controller.GetReverseWords("Reverse me");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetReverseWords_ShouldReturnValue()
        {
            var controller = new ChallengeController();
            var result = controller.GetReverseWords("Reverse me");
            var test = result as OkObjectResult;
            Assert.Equal("esreveR em", test.Value);
        }

        [Fact]
        public void GetToken_ShouldReturnOk_ShouldNotBeNull()
        {
            var controller = new ChallengeController();
            var result = controller.GetToken();
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetTriangelType_ShouldReturnOk()
        {
            var controller = new ChallengeController();
            var result = controller.GetTriangleType(3, 4, 5);
            var test = result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetTriangelType_ShouldReturnValue()
        {
            var controller = new ChallengeController();
            var result = controller.GetTriangleType(5, 5, 5);
            var test = result as OkObjectResult;
            Assert.Equal("Equilateral", test.Value);
        }

        [Fact]
        public void GetTriangelType_ShouldReturnOkError()
        {
            var controller = new ChallengeController();
            var result = controller.GetTriangleType(1, 4, 5);
            var test = result as OkObjectResult;
            Assert.Equal("Error", test.Value);
        }
    }
}