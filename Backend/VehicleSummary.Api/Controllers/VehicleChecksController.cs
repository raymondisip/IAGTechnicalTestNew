using System;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleSummary.Api.Service;

namespace VehicleSummary.Api.Controllers
{
    public class VehicleChecksController : Controller
    {
        private readonly IVehicleSummaryService _vehicleSummaryService;

        public VehicleChecksController(IVehicleSummaryService vehicleSummaryService)
        {
            _vehicleSummaryService = vehicleSummaryService;
        }
        
        // GET
        [HttpGet]
        [Route("/vehicle-checks/makes/{make}")]
        public async Task<IActionResult> GetVehicleMake(string make)
        {
            try
            {
                var response = await _vehicleSummaryService.GetSummaryByMake(make);

                return Ok(response);
            } catch (FlurlHttpException ex)
            {
               HttpStatusCode httpStatusCode = (HttpStatusCode)ex.Call.HttpStatus;
               if (httpStatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound();

                } else if (httpStatusCode == HttpStatusCode.Forbidden)
                {
                    return Forbid();
                } else
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}