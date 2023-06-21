namespace EnumDbDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CreateDepartments();

            GetDept(DepartmentNames.English);
            GetDept(DepartmentNames.Economics);
            GetDept(DepartmentNames.Math);
        }

        static void CreateDepartments()
        {
            SaveDept(
                new Department
                {
                    Id = 1,
                    Location = "Mumbai",
                    Name = DepartmentNames.Economics,
                    DeptNameInt = DepartmentNames.Economics
                });
            SaveDept(
                new Department
                {
                    Id = 2,
                    Location = "Indore",
                    Name = DepartmentNames.Math,
                    DeptNameInt = DepartmentNames.Math
                });
            SaveDept(
                new Department
                {
                    Id = 3,
                    Location = "Delhi",
                    Name = DepartmentNames.English,
                    DeptNameInt = DepartmentNames.English
                });
        }
        static Department SaveDept(Department dept)
        {
            using (var db = new EnumDbContext())
            {
                db.Departments.Add(dept);
                db.SaveChanges();
                return dept;
            }
        }

        static void GetDept(DepartmentNames deptName)
        {
            using (var db = new EnumDbContext())
            {
                var dept = (from d in db.Departments
                            where d.NameString == deptName.ToString()
                            select d).FirstOrDefault();

                Console.WriteLine($"Department Id: {dept.Id}" +
                    $" Department Name: {dept.Name}");

                var dept2 = (from d in db.Departments
                            where d.DeptNameInt == deptName
                            select d).FirstOrDefault();

                Console.WriteLine($"Department Id: {dept2.Id}" +
                    $" Department Name: {dept2.Name}" +
                    $" Department No.: {(int)(dept2.DeptNameInt)}");
            }
        }
    }
}