using System.ComponentModel.DataAnnotations.Schema;

namespace EnumDbDemo
{
    public enum DepartmentNames
    {
        English,
        Math,
        Economics
    }

    public class Department
    {
        public int Id { get; set; }

        // Store enum as string using 2 properties Name and NameString.
        [NotMapped]
        public DepartmentNames Name { get; set; }

        [Column("Name")]
        public string NameString
        {
            get { return this.Name.ToString(); }
            // private to prevent accidental updating.
            private set { this.Name = value.ParseEnum<DepartmentNames>(); }
        }

        public string Location { get; set; }

        // Store enum as number.
        public DepartmentNames DeptNameInt { get; set; }
    }

    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
