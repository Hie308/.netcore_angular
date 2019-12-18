using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModel.DTO
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email can't be longer than 50 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, ErrorMessage = "Password can't be longer than 30 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        [StringLength(50, ErrorMessage = "FullName can't be longer than 50 characters")]
        public string FullName { get; set; }
        public bool? Status { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public IEnumerable<DeviceDto> Devices { get; set; }
       
    }
}
