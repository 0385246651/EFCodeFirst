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

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name cannot be blank@!")]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Product Name can not use special characters !")]
        [MinLength(3, ErrorMessage = "Product Name must be at least 3 characters long@!")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price cannot be blank@!")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 100000, ErrorMessage = "Price must be between 0 and 100000@!")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Date  Purchase")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }

        [Required(ErrorMessage = "CategoryID cannot be blank@!")]
        public Nullable<long> CategoryID { get; set; }

        [Required(ErrorMessage = "BrandID cannot be blank@!")]
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
        public long Quantity { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }

    }
}