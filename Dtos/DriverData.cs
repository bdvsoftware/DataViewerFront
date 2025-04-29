using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerFront.Dtos
{
    internal class DriverData
    {
        public List<int> onboardTimestamps { get; set; }
        public List<int> batteryTimestamps { get; set; }

        public DriverData(List<int> onboardTimestamps, List<int> batteryTimestamps)
        {
            this.onboardTimestamps = onboardTimestamps;
            this.batteryTimestamps = batteryTimestamps;
        }
    }
}
