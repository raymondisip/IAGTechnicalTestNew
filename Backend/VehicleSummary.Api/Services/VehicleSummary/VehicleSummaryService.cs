using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using VehicleSummary.Api.Model;
using VehicleSummary.Api.Service;

namespace VehicleSummary.Api.Services.VehicleSummary

{
    public class VehicleSummaryService : IVehicleSummaryService
    {
        private static string API_VEHICLE_TYPE_BASE_URL = "https://api.iag.co.nz/vehicles/vehicletypes";
        private static string API_VEHICLE_TYPE_HEADER_OCP_APIM_SUBS_KEY = "Ocp-Apim-Subscription-Key";
        private static string API_VEHICLE_TYPE_HEADER_OCP_APIM_SUBS_VALUE = "72ec78fb999e43be8dbdac94d7236cae";

        public async Task<VehicleSummaryResponse> GetSummaryByMake(string make)
        {
            VehicleSummaryResponse response = new VehicleSummaryResponse();
            response.Models = new List<VehicleSummaryModels>();
            response.Make = make;
            List<string> models = await getModels(make);
            foreach (string model in models)
            {
                VehicleSummaryModels vsm = await getModelsYears(make, model);
                response.Models.Add(vsm);
            }
            return response;
        }

        async Task<List<string>> getModels(string make)
        {
            var response = await API_VEHICLE_TYPE_BASE_URL
                .AppendPathSegments("makes", make, "models")
                .SetQueryParam("api-version", "v1")
                .WithHeader(API_VEHICLE_TYPE_HEADER_OCP_APIM_SUBS_KEY, API_VEHICLE_TYPE_HEADER_OCP_APIM_SUBS_VALUE)
                .GetJsonAsync<List<string>>();
            return response;
        }

        async Task<VehicleSummaryModels> getModelsYears(string make, string model)
        {
            var response = await API_VEHICLE_TYPE_BASE_URL
                .AppendPathSegments("makes", make, "models", model, "years")
                .SetQueryParam("api-version", "v1")
                .WithHeader(API_VEHICLE_TYPE_HEADER_OCP_APIM_SUBS_KEY, API_VEHICLE_TYPE_HEADER_OCP_APIM_SUBS_VALUE)
                .GetJsonAsync<List<string>>();
            VehicleSummaryModels vsm = new VehicleSummaryModels();
            vsm.Name = model;
            vsm.Years = response;
            return vsm;
        }
    }
}