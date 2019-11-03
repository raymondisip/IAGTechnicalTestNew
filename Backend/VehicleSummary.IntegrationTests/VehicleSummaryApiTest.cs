using System;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using VehicleSummary.Api;
using System.Threading.Tasks;
using Xunit;
using System.Net;

namespace VehicleSummary.IntegrationTests
{
    public class VehicleSummaryApiTest
    {
        private readonly HttpClient httpClient;
        private readonly string API_VEHICLE_CHECK_BASE_URL = "vehicle-checks/makes/";
        public VehicleSummaryApiTest()
        {
            var server = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>());
            httpClient = server.CreateClient();
        }

        [Theory]
        [InlineData("Get")]
        public async Task Task_GetVehicleSummaryMake_Return_OkResult(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), API_VEHICLE_CHECK_BASE_URL + "Lotus");
            var response = await httpClient.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("Get")]
        public async Task Task_GetVehicleSummaryMake_Return_NotFoundResult(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), API_VEHICLE_CHECK_BASE_URL + "Dummy");
            var response = await httpClient.SendAsync(request);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
