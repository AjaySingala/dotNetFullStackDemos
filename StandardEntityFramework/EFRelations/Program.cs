using EFRelations.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EFRelations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating db context...");
            var db = new StudentDbContext();

            //// Reference Navigation Property.
            //CreateGrade(db, "First");
            //CreateGrade(db, "Seconed");
            //CreateGrade(db, "Third");
            GetGrades(db);

            //CreateStudent(db, "John", 1);
            //CreateStudent(db, "Mary", 2);
            //CreateStudent(db, "Gus", 1);
            //CreateStudent(db, "Sweet Tooth", 1);
            //CreateStudent(db, "Ellie", 3);
            //CreateStudent(db, "Jack", 2);
            GetStudents(db);

            //// Collection Navigation Property.
            //CreateCustomer(db, "John", 1, 5);
            //CreateCustomer(db, "Mary", 6, 8);
            //CreateCustomer(db, "Ellie", 11,14);
            //CreateCustomer(db, "Gus", 15,16);
            GetCustomers(db);

            // Many-to-Many.
            //CreateCourses(db);
            //CreateAssociates(db, "John", (new[] { "BA", "LLB" }));
            //CreateAssociates(db, "Mary", (new[] { "BCom", "MBA", "LLB" }));
            //CreateAssociates(db, "Gus", (new[] { "BSc", "MSc" }));
            //CreateAssociates(db, "Brian", (new[] { "BSc" }));

            GetAssociatesAndCourses(db);
            GetCoursesAndAssociates(db);

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }

        #region Many-to-Many Relationship

        static void CreateCourses(StudentDbContext db)
        {
            var courses = new HashSet<Course>
            {
                new Course { Name = "BCom" },
                new Course { Name = "BA" },
                new Course { Name = "BSc" },
                new Course { Name = "MSc" },
                new Course { Name = "LLB" },
            };
            db.Courses.AddRange(courses);
            db.SaveChanges();
        }

        static void CreateAssociates(StudentDbContext db, string name, string[] coursesToAdd)
        {
            var courses = db.Courses.Where(c => coursesToAdd.Contains(c.Name)).ToList<Course>();
            var associate = new Associate
            {
                Name = name,
                Courses = courses,
            };
            
            db.Associates.Add(associate);

            db.SaveChanges();
        }

        static void GetAssociatesAndCourses(StudentDbContext db)
        {
            Console.WriteLine("\n GetAssociatesAndCourses");
            // .Include() ==> Eager Loading.
            var associates = db.Associates.Include("Courses");
            foreach(var associate in associates)
            {
                Console.WriteLine($"Associate: {associate.Id} | {associate.Name}");
                foreach(var course in associate.Courses)
                {
                    Console.WriteLine($"\t Course: {course.Id} | {course.Name}");
                }
            }
        }

        static void GetCoursesAndAssociates(StudentDbContext db)
        {
            Console.WriteLine("\n GetCoursesAndAssociates");
            // .Include() ==> Eager Loading.
            var courses = db.Courses.Include("Associates");
            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.Id} | {course.Name}");
                foreach (var associate in course.Associates)
                {
                    Console.WriteLine($"\t Associate: {associate.Id} | {associate.Name}");
                }
            }
        }

        #endregion

        #region Collection Navigation Property

        static void CreateCustomer(StudentDbContext db, string name, int start, int stop)
        {
            Console.WriteLine("\nCreateCustomer");
            Random rnd = new Random();

            Customer customer = new Customer
            {
                Name = name
            };

            var orders = new List<Order>();
            int max = rnd.Next(start, stop);
            for (int i = start; i <= max; i++)
            {
                var order = new Order { 
                    Customer = customer, 
                    OrderDate = new DateTime(2023, rnd.Next(1, 12), rnd.Next(1, 28)) 
                };
                db.Orders.Add(order);
                orders.Add(order);
            }

            customer.Orders = orders;

            db.SaveChanges();
        }

        static void GetCustomers(StudentDbContext db)
        {
            Console.WriteLine("\nGetCustomers");
            var customers = db.Customers;
            // .Include() ==> Eager Loading.
            //var customers = db.Customers.Include("Orders");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id} | {customer.Name}");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"\t - {order.Id} | {order.OrderDate}");
                }
            }
        }

        #endregion

        #region Reference Navigation Property

        static void CreateStudent(StudentDbContext db, string studentName, int gradeId)
        {
            Console.WriteLine("\nCreateStudent");
            var grade = db.Grades.Find(gradeId);

            var student = new Student
            {
                StudentName = studentName,
                Grade = grade
            };
            db.Students.Add(student);
            db.SaveChanges();
        }

        static void GetStudents(StudentDbContext db)
        {
            Console.WriteLine("\nGetStudents");
            var students = db.Students;
            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentId} | {student.StudentName} | Grade: {student.Grade.GradeName}");
            }
        }



        static void CreateGrade(StudentDbContext db, string gradeName)
        {
            Console.WriteLine("\nCreateGrade");
            var grade = new Grade
            {
                GradeName = gradeName
            };
            db.Grades.Add(grade);
            db.SaveChanges();
        }

        static void GetGrades(StudentDbContext db)
        {
            Console.WriteLine("\nGetGrades");
            var grades = db.Grades;
            foreach (var grade in grades)
            {
                Console.WriteLine($"{grade.GradeId} | {grade.GradeName}");
            }
        }

        #endregion
    }
}
