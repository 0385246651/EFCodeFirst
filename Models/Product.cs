﻿using System;
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
		public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }

    }
}