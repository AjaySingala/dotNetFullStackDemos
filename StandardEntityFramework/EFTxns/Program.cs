using EFTxns.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFTxns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating db context...");
            var db = new EFTxnsDbContext();

            //CreateCourses(db);
            //CreateAssociates(db, "John", (new[] { "BA", "LLB" }));
            //CreateAssociates(db, "Mary", (new[] { "BCom", "MBA", "LLB" }));
            //CreateAssociates(db, "Gus", (new[] { "BSc", "MSc" }));
            //CreateAssociates(db, "Brian", (new[] { "BSc" }));
            //CreateStandards(db, (new[] { "First Level", "Second Level", "Third Level" }));
            //MapAssociateStandard(db, 1, 3);
            //MapAssociateStandard(db, 2, 1);
            //MapAssociateStandard(db, 3, 2);
            //MapAssociateStandard(db, 4, 3);

            GetAssociatesAndCourses(db);
            GetCoursesAndAssociates(db);

            //// Txn.
            //MultipleTxns(db);
            //SingleTxn(db, false);
            //SingleTxn(db, true);

            //// Async Query and Save.
            //AsyncAssociateQueryAndSave(db);

            // Explicit Loading.
            ExplicitLoading(db);

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }

        #region Explicit Loading

        static void ExplicitLoading(EFTxnsDbContext db)
        {
            Console.WriteLine("\n ExplicitLoading");
            var associate = db.Associates
                .Where(a => a.Name == "John")
                .FirstOrDefault<Associate>();

            Console.WriteLine($"\t {associate.Name}");
            Console.WriteLine($"\t {associate.Standard.Name}");     // Error here.

            db.Entry(associate).Reference(a => a.Standard).Load();
            //Console.WriteLine($"\t Standard: {associate.Standard.Name}");     // Works here.

            //// For collections, do this:
            //db.Entry(associate).Collection(a => a.Courses).Load();
            //Console.WriteLine("\t Courses:");
            //foreach(var course in associate.Courses)
            //{
            //    Console.WriteLine($"\t\t {course.Name}");
            //}
        }

        #endregion

        #region EntityFramework Transactions

        #region Txns.

        static void SingleTxn(EFTxnsDbContext db, bool toFail)
        {
            Console.WriteLine($"\n SingleTxn will fail? {toFail}");
            db.Database.Log = Console.Write;    // Output log to console.

            using (var txn = db.Database.BeginTransaction())    // New Txn.
            {
                try
                {
                    var standard = db.Standards.Add(
                        new Standard { Name = "Another Dummy Standard" }
                    );

                    db.Associates.Add(
                        new Associate { Name = "Another Dummy Associate", Standard = standard }
                    );
                    db.SaveChanges();       // No New Txn.

                    if(toFail)  // For Rollback demo.
                    {
                        throw new Exception("Failing delibrately...");
                    }

                    db.Courses.Add(new Course() { Name = "BTech" });
                    db.SaveChanges();       // No New Txn.

                    txn.Commit();   // THIS!!!
                }
                catch (Exception ex)
                {
                    txn.Rollback();     // WHOA!!!
                    Console.WriteLine($"ERROR! {ex.Message}");
                }
            }
        }

        static void MultipleTxns(EFTxnsDbContext db)
        {
            Console.WriteLine("\n MultipleTxns");
            db.Database.Log = Console.Write;    // Output log to console.

            var standard = db.Standards.Add(
                new Standard { Name = "Dummy Standard" }
            );

            db.Associates.Add(
                new Associate { Name = "Dummy Associate", Standard = standard }
            );
            db.SaveChanges();       // New Txn.

            db.Courses.Add(new Course() { Name = "Computer Science" });
            db.SaveChanges();       // New Txn.
        }

        #endregion

        #region Create Courses and Associates

        static void MapAssociateStandard(EFTxnsDbContext db, int associateId, int standardId)
        {
            Console.WriteLine("\n MapAssociateStandard");
            var associate = db.Associates.Find(associateId);
            var standard = db.Standards.Find(standardId);

            associate.Standard = standard;

            db.Entry(associate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        static void CreateStandards(EFTxnsDbContext db, string[] standardNames)
        {
            Console.WriteLine("\n CreateStandards");
            var standards = new List<Standard>();
            foreach (var name in standardNames)
            {
                standards.Add(new Standard { Name = name });
            }
            db.Standards.AddRange(standards);

            db.SaveChanges();
        }

        static void CreateCourses(EFTxnsDbContext db)
        {
            Console.WriteLine("\n CreateCourses");
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

        static void CreateAssociates(EFTxnsDbContext db, string name, string[] coursesToAdd)
        {
            Console.WriteLine("\n CreateAssociates");
            var courses = db.Courses.Where(c => coursesToAdd.Contains(c.Name)).ToList<Course>();
            var associate = new Associate
            {
                Name = name,
                Courses = courses,
            };

            db.Associates.Add(associate);

            db.SaveChanges();
        }

        static void GetAssociatesAndCourses(EFTxnsDbContext db)
        {
            Console.WriteLine("\n GetAssociatesAndCourses");
            // .Include() ==> Eager Loading.
            var associates = db.Associates.Include("Courses");
            foreach (var associate in associates)
            {
                Console.WriteLine($"Associate: {associate.Id} | {associate.Name}");
                foreach (var course in associate.Courses)
                {
                    Console.WriteLine($"\t Course: {course.Id} | {course.Name}");
                }
            }
        }

        static void GetCoursesAndAssociates(EFTxnsDbContext db)
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

        #endregion

        #region Async Query and Save.

        static void AsyncAssociateQueryAndSave(EFTxnsDbContext db)
        {
            var query = GetAssociateAsync(db);
            Console.WriteLine("Do something else here till we get the query result..");

            query.Wait();

            var associate = query.Result;

            associate.Name = "Dummy Associate";

            var associateSave = SaveAssociateAsync(db, associate);

            Console.WriteLine("Do something else here till we save a associate..");

            associateSave.Wait();

            Console.WriteLine("Saved Entities: {0}", associateSave.Result);
        }

        static async Task<int> SaveAssociateAsync(EFTxnsDbContext db, Associate associate)
        {
            Console.WriteLine("\n SaveAssociateAsync");
            Console.WriteLine("Start saving Associate...");

            db.Entry(associate).State = EntityState.Modified;
            Console.WriteLine($"Update Associate Name to {associate.Name}");

            int x = await (db.SaveChangesAsync());
            Console.WriteLine("Finished saving Associate...");
            return x;
        }

        static async Task<Associate> GetAssociateAsync(EFTxnsDbContext db)
        {
            Console.WriteLine("\n GetAssociateAsync");
            Console.WriteLine("Start getting Associate...");
            var associate = await (db.Associates
                .Where(a => a.Id == 5)
                .FirstOrDefaultAsync<Associate>());

            Console.WriteLine($"Finished getting Associate...{associate.Name}");
            return associate;
        }

        #endregion
    }
}
