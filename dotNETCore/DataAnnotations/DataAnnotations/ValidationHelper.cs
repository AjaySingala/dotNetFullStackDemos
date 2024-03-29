﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    public static class ValidationHelper
    {
        public static List<ValidationMessage>
            Validate<T>(T entity)
        {
            List<ValidationMessage> ret = new();

            ValidationContext context = new(entity,
                serviceProvider: null, items: null);
            List<ValidationResult> results = new();

            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                foreach (ValidationResult item in results)
                {
                    string propName = string.Empty;
                    if (item.MemberNames.Any())
                    {
                        propName = ((string[])item.MemberNames)[0];
                    }
                    ValidationMessage msg = new()
                    {
                        ErrorMessage = item.ErrorMessage,
                        PropertyName = propName
                    };

                    ret.Add(msg);
                }
            }

            return ret;
        }
    }
}
