using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    public class ProductViewModel
    {
        public Product Entity { get; set; }

        public ProductViewModel()
        {
            Entity = new();
        }

        #region Demo #1.
        //public List<ValidationMessage> Validate()
        //{
        //    List<ValidationMessage> msgs = new();

        //    if (string.IsNullOrWhiteSpace(Entity.Name))
        //    {
        //        msgs.Add(new ValidationMessage()
        //        {
        //            ErrorMessage = "Product Name Must Be Filled In.",
        //            PropertyName = "Name"
        //        });
        //    }
        //    else
        //    {
        //        if (Entity.Name.Length > 50)
        //        {
        //            msgs.Add(new ValidationMessage()
        //            {
        //                ErrorMessage = "Product Name Must Be 50 Characters or Less.",
        //                PropertyName = "Name"
        //            });
        //        }
        //    }

        //    if (Entity.StandardCost == null || Entity.StandardCost < 0.01M)
        //    {
        //        msgs.Add(new ValidationMessage()
        //        {
        //            ErrorMessage = "Cost Must Be Greater Than Zero.",
        //            PropertyName = "StandardCost"
        //        });
        //    }
        //    if (Entity.ListPrice == null || Entity.ListPrice < 0.01M)
        //    {
        //        msgs.Add(new ValidationMessage()
        //        {
        //            ErrorMessage = "Price Must Be Greater Than Zero.",
        //            PropertyName = "ListPrice"
        //        });
        //    }
        //    if (Entity.ListPrice < Entity.StandardCost)
        //    {
        //        msgs.Add(new ValidationMessage()
        //        {
        //            ErrorMessage = $"Price must be greater than the Cost.",
        //            PropertyName = "ListPrice"
        //        });
        //    }

        //    if (Entity.SellStartDate == DateTime.MinValue)
        //    {
        //        msgs.Add(new ValidationMessage()
        //        {
        //            ErrorMessage = $"Selling Start Date Must Be Greater Than '{DateTime.Now.AddDays(-5).ToShortDateString()}'.", 
        //            PropertyName = "SellStartDate"
        //        });
        //    }

        //    return msgs;
        //}

        #endregion

        #region Demo #2
        public List<ValidationMessage> Validate()
        {
            List<ValidationMessage> msgs = new();

            // Create instance of ValidationContext object
            ValidationContext context = new(Entity, serviceProvider: null,
                items: null);
            List<ValidationResult> results = new();

            // Call TryValidateObject() method
            if (!Validator.TryValidateObject(Entity, context, results, true))
            {
                // Get validation results
                foreach (ValidationResult item in results)
                {
                    string propName = string.Empty;
                    if (item.MemberNames.Any())
                    {
                        propName = ((string[])item.MemberNames)[0];
                    }
                    // Build new ValidationMessage object
                    ValidationMessage msg = new()
                    {
                        ErrorMessage = item.ErrorMessage,
                        PropertyName = propName
                    };

                    // Add validation object to list
                    msgs.Add(msg);
                }
            }

            return msgs;
        }
        #endregion

        #region using Generic Validation Helper class for Validate().
        //public List<ValidationMessage> Validate()
        //{
        //    // Use Helper Class
        //    return ValidationHelper.Validate(Entity);
        //}
        #endregion
    }
}
