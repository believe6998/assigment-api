using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace undefined_shoes_api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string UrlImage { get; set; }
        public DateTime CreatedAt
        {
            get
            {
                return this.createdAt.HasValue
                    ? this.createdAt.Value
                    : DateTime.Now;
            }

            set { this.createdAt = value; }
        }
        private DateTime? createdAt = null; 
        public DateTime UpdatedAt
        {
            get
            {
                return this.updatedAt.HasValue
                    ? this.updatedAt.Value
                    : DateTime.Now;
            }

            set { this.updatedAt = value; }
        }
        private DateTime? updatedAt = null;
        public int Status { get; set; } = 1;
        public int CategoryId { get; set; }

    }
}