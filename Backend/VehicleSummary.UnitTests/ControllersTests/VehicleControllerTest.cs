using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using VehicleSummary.Api.Controllers;
using VehicleSummary.Api.Model;
using VehicleSummary.Api.Service;
using Xunit;
using System.Linq;
using Flurl.Http;
using System.Net;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace VehicleSummary.UnitTests.ControllersTests
{
    public class VehicleControllerTest
    {
        private readonly VehicleChecksController controller;
        private readonly IVehicleSummaryService mockVehicleSummaryService;

        public VehicleControllerTest()
        {
            mockVehicleSummaryService = A.Fake<IVehicleSummaryService>();
            controller = new VehicleChecksController(mockVehicleSummaryService);
        }

        [Fact]
        public async Task Task_GetVehicleSummaryMake_Return_OkResult()
        {
            var make = "Lotus";
            VehicleSummaryResponse mockVehicleSummaryResponse = new VehicleSummaryResponse();
            mockVehicleSummaryResponse.Make = "Lotus";
            VehicleSummaryModels vehicelSummaryModel = new VehicleSummaryModels();
            int[] years = new[] { 1990, 2000 };
            vehicelSummaryModel.Years.Add("1990");
            vehicelSummaryModel.Years.Add("2003");
            mockVehicleSummaryResponse.Models.Add(vehicelSummaryModel);

            A.CallTo(() => mockVehicleSummaryService.GetSummaryByMake(make))
                .Returns(mockVehicleSummaryResponse);


            var response = await controller.GetVehicleMake(make);
            A.CallTo(() => mockVehicleSummaryService.GetSummaryByMake(make)).Returns(mockVehicleSummaryResponse);

        }

        [Fact]
        public async Task Task_GetVehicleSummaryMake_Return_NotFoundResult()
        {
            var make = "Lotus";
            var notFoundCall = new HttpCall
            {
                Response = new HttpResponseMessage(HttpStatusCode.NotFound)
            };
            A.CallTo(() => mockVehicleSummaryService.GetSummaryByMake(make))
                .ThrowsAsync(new FlurlHttpException(notFoundCall, "exception", new Exception()));
            var response = await controller.GetVehicleMake(make);
            Assert.IsType<NotFoundResult>(response);

        }

        [Fact]
        public async Task Task_GetVehicleSummaryMake_Return_ForbiddenResult()
        {
            var make = "Lotus";
            var forbiddenCall = new HttpCall
            {
                Response = new HttpResponseMessage(HttpStatusCode.Forbidden)
            };
            A.CallTo(() => mockVehicleSummaryService.GetSummaryByMake(make))
                .ThrowsAsync(new FlurlHttpException(forbiddenCall, "exception", new Exception()));
            var response = await controller.GetVehicleMake(make);
            Assert.IsType<ForbidResult>(response);

        }

        [Fact]
        public async Task Task_GetVehicleSummaryMake_Return_InternalErrorResult()
        {
            var make = "Lotus";
            var internalErrorCall = new HttpCall
            {
                Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            };
            A.CallTo(() => mockVehicleSummaryService.GetSummaryByMake(make))
                .ThrowsAsync(new FlurlHttpException(internalErrorCall, "exception", new Exception()));
            var response = await controller.GetVehicleMake(make);
            var actualResult = (StatusCodeResult)response;
            var expectedResult = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            Assert.Equal(expectedResult.StatusCode, actualResult.StatusCode);
        }
    }
}
