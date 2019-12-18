using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CozaStorev2.Models
{
    public partial class Devices
    {
        [Required(ErrorMessage = "This field is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public string FullName { get; set; }
        public string ProductType { get; set; }
        public string BranchName { get; set; }
        public string Origin { get; set; }
        public string SerialNumber { get; set; }
        public int? QualityStatus { get; set; }
        public int? OwnerId { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int LastUpdateBy { get; set; }

        public Locations CurrentLocation { get; set; }
        public Users Owner { get; set; }
        public string LocationHistory { get; set; }
        public int? GroupDeviceId { get; set; }
    }
}
