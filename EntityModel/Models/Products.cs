using System;
using System.Collections.Generic;

namespace CozaStorev2.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public string Sizes { get; set; }
        public string Color { get; set; }
        public string ProfileImg { get; set; }
        public bool? Status { get; set; }
        public string Dimensions { get; set; }
        public string Meterials { get; set; }
        public string ProdDescription { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
