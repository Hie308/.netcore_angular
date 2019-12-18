using System;
using System.Collections.Generic;

namespace CozaStorev2.Models
{
    public partial class Customers
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Addr { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddr { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }
        public DateTime? Birthday { get; set; }
        public string Avatar { get; set; }
        public string Profile { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
