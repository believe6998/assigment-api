using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace undefined_shoes_api.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; } = 1;
    }
}