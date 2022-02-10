namespace FilterDemos.Models
{
    public class Person : IEntity
    {
        public int Id { get ; set ; }
        public string Name { get; set; } = string.Empty;
    }

    public class InvalidPerson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
