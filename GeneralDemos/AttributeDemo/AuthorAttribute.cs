using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    [AttributeUsage(System.AttributeTargets.Class |
        System.AttributeTargets.Struct,
        AllowMultiple = true)
    ]
    //[AttributeUsage(System.AttributeTargets.Class |
    //    System.AttributeTargets.Struct)
    //]
    public class AuthorAttribute : Attribute
    {
        private string Name;
        public double Version { get; set; }

        public AuthorAttribute(string name)
        {
            Name = name;
            Version = 1.0;
        }
    }
}
