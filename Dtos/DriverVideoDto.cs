using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerFront.Dtos
{
    internal class DriverVideoDto
    {
        public IEnumerable<DriverOnboardDto>? DriverOnboardDto { get; set; }
        public IEnumerable<DriverBatteryDto>? DriverBatteryDto { get; set; }

        public DriverVideoDto(IEnumerable<DriverOnboardDto>? driverOnboardDto, IEnumerable<DriverBatteryDto>? driverBatteryDto)
        {
            DriverOnboardDto = driverOnboardDto;
            DriverBatteryDto = driverBatteryDto;
        }
    }
}
