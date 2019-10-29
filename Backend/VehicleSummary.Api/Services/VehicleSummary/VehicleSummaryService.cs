using System;
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
        public async Task<VehicleSummaryResponse> GetSummaryByMake(string make)
        {
            VehicleSummaryResponse response = new VehicleSummaryResponse();
            response.Models = new List<VehicleSummaryModels>();
            response.Make = make;
            List<string> models = await getModels(make);
            foreach (string model in models)
            {
                VehicleSummaryModels vsm = new VehicleSummaryModels();
                vsm.Name = model;
                int years = await getModelsYearCount(make, model);
                vsm.YearsAvailable = years;
                response.Models.Add(vsm);
            }
            return response;
        }

        async Task<List<string>> getModels(string make)
        {
            var modelsUrl = "https://api.iag.co.nz/vehicles/vehicletypes"; ///makes/Lotus/models?api-version=v1";

            var response = await modelsUrl
                .AppendPathSegments("makes", make, "models")
                .SetQueryParam("api-version", "v1")
                .WithHeader("Ocp-Apim-Subscription-Key", "72ec78fb999e43be8dbdac94d7236cae")
                .GetJsonAsync<List<string>>();

            return response;
        }

        async Task<int> getModelsYearCount(string make, string model)
        {
            var modelsUrl = "https://api.iag.co.nz/vehicles/vehicletypes"; ///makes/Lotus/models?api-version=v1";
            var response = await modelsUrl
                .AppendPathSegments("makes", make, "models", model, "years")
                .SetQueryParam("api-version", "v1")
                .WithHeader("Ocp-Apim-Subscription-Key", "72ec78fb999e43be8dbdac94d7236cae")
                .GetJsonAsync<List<string>>();

            return response.Count;
        }
    }
}