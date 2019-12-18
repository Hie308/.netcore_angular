using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModel.DTO
{
    public class LocationForCreationDto
    {

        [Required(ErrorMessage = "AreaCode is required")]
        [StringLength(50, ErrorMessage = "AreaCode can't be longer than 10 characters")]
        public string AreaCode { get; set; }

        [Required(ErrorMessage = "Adrress is required")]
        [StringLength(50, ErrorMessage = "Adrress can't be longer than 50 characters")]
        public string Adrress { get; set; }

        public bool? Status { get; set; }
        public double? Revenue { get; set; }
        public int? Leader { get; set; }

        IEnumerable<DeviceDto> Devices { get; set; }
    }
}
