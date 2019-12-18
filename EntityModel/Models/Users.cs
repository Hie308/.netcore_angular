using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CozaStorev2.Models
{
    public partial class Users
    {
        public Users()
        {
            Devices = new HashSet<Devices>();
        }
        [Required(ErrorMessage = "This field is required")]

        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool? Status { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public ICollection<Devices> Devices { get; set; }
    }
}
