using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSummary.Api.Model
{
    public class VehicleSummaryResponse
    {
        public string Make { get; set; }

        public List<VehicleSummaryModels> Models { get; set; } = new List<VehicleSummaryModels>();
    }

    public class VehicleSummaryModels
    {
        public string Name { get; set; }
        public int YearsAvailable
        {
            get { return Years.Count; }
        }

        public List<string> Years { get; set; } = new List<string>();
    }
}
