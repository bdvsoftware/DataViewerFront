using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerFront.Dtos
{
    internal class DriverBatteryRangeDto
    {
        public string DriverName { get; set; }
        public string DriverAbbreviation { get; set; }
        public int FrameId { get; set; }
        public int BatteryFrameId { get; set; }
        public int? Lap { get; set; }
        public String Status { get; set; }
        public string TimeRange { get; set; }

        public DriverBatteryRangeDto(string driverName, string driverAbbreviation, string timeRange, int frameId, int batteryFrameId, int? lap, string status)
        {
            DriverName = driverName;
            DriverAbbreviation = driverAbbreviation;
            FrameId = frameId;
            BatteryFrameId = batteryFrameId;
            Lap = lap;
            Status = status;
            TimeRange = timeRange;
        }
    }
}
