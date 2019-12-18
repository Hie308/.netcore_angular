using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModel.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool? Status { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        //public IEnumerable<DeviceDto> Devices { get; set; }
    }
}

