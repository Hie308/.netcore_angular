using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModel.DTO
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string AreaCode { get; set; }
        public string Adrress { get; set; }
        public bool? Status { get; set; }
        public double? Revenue { get; set; }
        public int? Leader { get; set; }

        //IEnumerable<DeviceDto> Devices { get; set; }
    }
}
