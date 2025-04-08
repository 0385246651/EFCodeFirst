using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Validte class with EF
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirst.Models
{
	public class Brand
	{
        [Key]
        public long BrandID { get; set; }
        public string BrandName { get; set; }
    }
}