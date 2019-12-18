using System;
using System.Collections.Generic;

namespace CozaStorev2.Models
{
    public partial class ProductImages
    {
        public int ProdId { get; set; }
        public string ImgPath { get; set; }
        public bool? ImgStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
