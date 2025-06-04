using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerFront.Dtos
{
    internal class UpdateFrameRequestDto
    {
        public int? VideoId { get; set; }
        public int Timestamp { get; set; }
        public int Lap { get; set; }
        public string DriverAbbr { get; set; }

        public UpdateFrameRequestDto(int? videoId, int timestamp, int lap, string driverAbbr)
        {
            VideoId = videoId;
            Timestamp = timestamp;
            Lap = lap;
            DriverAbbr = driverAbbr;
        }
    }
}
