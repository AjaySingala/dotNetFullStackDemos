﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    // Is Date Greater Than Minimum Date.
    public class DateMinimumAttribute : ValidationAttribute
    {
        public DateMinimumAttribute(string minDate)
        {
            _minDate = Convert.ToDateTime(minDate);
        }

        private readonly DateTime _minDate;

        protected override ValidationResult IsValid(
          object value, ValidationContext vc)
        {
            if (value != null)
            {
                // Get the value entered
                DateTime dateEntered = (DateTime)value;

                // Get display name for validation message
                string displayName = vc.DisplayName;

                // If the date entered is less than
                // or equal to the minimum date set
                // return an error
                if (dateEntered <= _minDate)
                {
                    // Check if ErrorMessage is filled in
                    if (string.IsNullOrEmpty(ErrorMessage))
                    {
                        ErrorMessage = $"{displayName} must be greater than or equal to '{_minDate:dd/MM/yyyy}'.";
                    }

                    return new ValidationResult(ErrorMessage,
                           new[] { vc.MemberName });
                }
            }

            return ValidationResult.Success;
        }
    }
}
