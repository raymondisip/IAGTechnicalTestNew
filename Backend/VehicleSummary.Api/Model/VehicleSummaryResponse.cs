using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSummary.Api.Model
{
    public class VehicleSummaryResponse
    {
        private List<VehicleSummaryModels> models = new List<VehicleSummaryModels>();

        public string Make { get; set; }

        public List<VehicleSummaryModels> Models
        {
            get { return models; }
            set { models = value; }
        }
    }

    public class VehicleSummaryModels
    {
        private List<string> years = new List<string>();

        public string Name { get; set; }
        public int YearsAvailable
        {
            get { return years.Count; }
        }

        public List<string> Years
        {
            get { return years; }
            set { years = value; }
        }
    }
}
