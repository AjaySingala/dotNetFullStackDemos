using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    public class Product
    {
        public int ProductID { get; set; }
       
        //[Required]
        [Required(ErrorMessage = "{0} Must Be Filled In.")]
        [Display(Name = "Product Name")]
        //[MaxLength(25)]
        [StringLength(50, MinimumLength = 4,
            ErrorMessage = "{0} Can Only Have Between {2} and {1} Characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Must Be Filled In")]
        [Display(Name = "Product Number")]
        public string ProductNumber { get; set; }
        [Display(Name = "Product Color")]
        [MaxLength(15)]
        [MinLength(3, ErrorMessage = "{0} Must Have {1} Characters or More.")]
        public string Color { get; set; }
        [Required]
        //[Range(0.01, 9999, ErrorMessage = "{0} must be between {1} and {2}")]
        [Range(0.01, 9999, ErrorMessage = "{0} must be between {1:c} and {2:c}")]
        [Display(Name = "Cost")]
        public decimal? StandardCost { get; set; }
        [Required]
        [Display(Name = "Price")]
        //[Range(0.01, 9999, ErrorMessage = "{0} must be between {1:c} and {2:c}")]
        [Range(0.01, 9999, ErrorMessage = "{0} must be between {1} and {2}")]
        public decimal? ListPrice { get; set; }
        [Required]
        [Display(Name = "Start Selling Date")]
        [Range(typeof(DateTime), "1/1/2000", "31/12/2030",
            ErrorMessage = "{0} must be between {1:d} and {2:d}")]
        public DateTime SellStartDate { get; set; }
        [Display(Name = "End Selling Date")]
        [Range(typeof(DateTime), "1/1/2000", "31/12/2030",
            ErrorMessage = "{0} must be between {1:d} and {2:d}")]
        [DateMaximum("31/12/2030")]
        public DateTime? SellEndDate { get; set; }
        [Display(Name = "Date Discontinued")]
        [DateMinimum("9/1/2022")]
        public DateTime? DiscontinuedDate { get; set; }

        [Display(Name = "Product URL")]
        [Url]
        public string ProductUrl { get; set; }


        public override string ToString()
        {
            return $"{Name} ({ProductID})";
        }
    }
}
