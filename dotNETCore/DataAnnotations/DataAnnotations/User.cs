using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    public class User
    {
        public int UserId { get; set; }
        public string LoginId { get; set; }
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        //[EmailAddress]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a - zA - Z]{2, 3}$",
            ErrorMessage = "The email address entered is not valid.")]
        public string EmailAddress { get; set; }
        //[Phone]
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d { 4}",
            ErrorMessage = "The phone number entered is not valid.  Please use the format(nnn) nnn - nnnn")]
        public string Phone { get; set; }
    }
}
