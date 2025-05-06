using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerFront.Dtos
{
    internal class DriverVideoDto
    {
        public IEnumerable<DriverOnboardRangeDto>? DriverOnboardRangeDto { get; set; }
        public IEnumerable<DriverBatteryRangeDto>? DriverBatteryRangeDto { get; set; }

        public DriverVideoDto(IEnumerable<DriverOnboardRangeDto>? driverOnboardRangeDto, IEnumerable<DriverBatteryRangeDto>? driverBatteryRangeDto)
        {
            DriverOnboardRangeDto = driverOnboardRangeDto;
            DriverBatteryRangeDto = driverBatteryRangeDto;
        }
    }
}
