using System;
using System.Collections.Generic;

namespace CozaStorev2.Models
{
    public partial class Menus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool? Status { get; set; }
        public string GroupId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
