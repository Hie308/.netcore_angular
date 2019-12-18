using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CozaStorev2.Models
{
    public partial class Locations
    {
        public Locations()
        {
            Devices = new HashSet<Devices>();
        }
        [Required(ErrorMessage = "This field is required")]

        public int Id { get; set; }
        public string AreaCode { get; set; }
        public string Adrress { get; set; }
        public bool? Status { get; set; }
        public double? Revenue { get; set; }
        public int? Leader { get; set; }

        public ICollection<Devices> Devices { get; set; }
    }
}
