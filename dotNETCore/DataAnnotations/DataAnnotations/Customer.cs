using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    public class Customer
    {
        [CustomValidation(typeof(WeekdayOnlyValidator), nameof(WeekdayOnlyValidator.Validate))]
        public DateTime EntryDate { get; set; }
    }
}
