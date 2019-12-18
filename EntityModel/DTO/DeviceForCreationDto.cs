using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModel.DTO
{
    public class DeviceForCreationDto
    {
        [Required(ErrorMessage = "FullName is required")]
        [StringLength(50, ErrorMessage = "FullName can't be longer than 50 characters")]
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
        [Required(ErrorMessage = "LastUpdateBy is required")]
        public int LastUpdateBy { get; set; }
        //public int Owner { get; set; }
        //public int CurrentLocation { get; set; }
        
    }
}
