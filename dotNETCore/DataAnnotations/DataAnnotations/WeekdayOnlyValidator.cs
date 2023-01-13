using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    public class WeekdayOnlyValidator
    {
        public static ValidationResult Validate(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
             || date.DayOfWeek == DayOfWeek.Sunday
                 ? new ValidationResult("Invalid date because it falls on a weekend"): ValidationResult.Success;
        }
    }
}
