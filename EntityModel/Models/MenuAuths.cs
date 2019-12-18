using System;
using System.Collections.Generic;

namespace CozaStorev2.Models
{
    public partial class MenuAuths
    {
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public bool? Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
