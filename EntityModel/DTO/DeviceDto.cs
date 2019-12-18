using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModel.DTO
{
    public class DeviceDto
    {
        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ProductType { get; set; }
        public string BranchName { get; set; }
        public string Origin { get; set; }
        public string SerialNumber { get; set; }
        public int QualityStatus { get; set; }
        public int OwnerId { get; set; }
        public int CurrentLocationId { get; set; }
        public int Quantity { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int LastUpdateBy { get; set; }

        public IEnumerable<LocationDto> CurrentLocation { get; set; }
        public IEnumerable<UserDto> Owner { get; set; }
        public string LocationHistory { get; set; }
        public int? GroupDeviceId { get; set; }

    }
}
