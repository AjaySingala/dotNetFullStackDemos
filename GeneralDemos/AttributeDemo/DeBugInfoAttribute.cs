using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Constructor |
        AttributeTargets.Field |
        AttributeTargets.Method |
        AttributeTargets.Property,
        AllowMultiple = true)
    ]
    public class DeBugInfoAttribute : System.Attribute
    {
        public DeBugInfoAttribute(int bugNumber, string developer, string lastReviewOn)
        {
            BugNo = bugNumber;
            Developer = developer;
            LastReview = lastReviewOn;
        }

        public int BugNo { get; }
        public string Developer { get;  }
        public string LastReview { get; }
        public string Message { get; set; }
    }
}
