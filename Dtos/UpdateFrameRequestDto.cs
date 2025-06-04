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
        public int InitTime { get; set; }
        public int EndTime { get; set; }
        public int? Lap { get; set; }
        public string DriverAbbr { get; set; }

        public UpdateFrameRequestDto(int? videoId, int initTime, int endTime, int? lap, string driverAbbr)
        {
            VideoId = videoId;
            InitTime = initTime;
            EndTime = endTime;  
            Lap = lap;
            DriverAbbr = driverAbbr;
        }
    }
}
