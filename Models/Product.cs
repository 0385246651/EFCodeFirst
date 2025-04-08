using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirst.Models
{
	public class Product
	{
        [Key]
		public long ProductID { get; set; }
        public string ProductName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> Price { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
        public long Quantity { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }

    }
}