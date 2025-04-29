using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerFront.Dtos
{
    internal class DriverBatteryDto
    {
        public string DriverName { get; set; }
        public string DriverAbbreviation { get; set; }
        public int Timestamp { get; set; }
        public int FrameId { get; set; }
        public int BatteryFrameId { get; set; }
        public int Lap { get; set; }
        public int Status { get; set; }

        public DriverBatteryDto(string driverName, string driverAbbreviation, int timestamp, int frameId, int batteryFrameId, int lap, int status)
        {
            DriverName = driverName;
            DriverAbbreviation = driverAbbreviation;
            Timestamp = timestamp;
            FrameId = frameId;
            BatteryFrameId = batteryFrameId;
            Lap = lap;
            Status = status;
        }
    }
}
