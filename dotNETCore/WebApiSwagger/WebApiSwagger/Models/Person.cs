using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Person
    {
        // [Required]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
