using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace EFCoreTutorialConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Thêm cấu hình tệp appsettings.json
            //var configuration = new ConfigurationBuilder()
            //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //        .Build();

            using (var context = new SchoolDbContext())
            {
                context.Database.EnsureCreated();

                ////create entity objects
                var grd1 = new Grade() { GradeName = "1st Grade 312312" };

                var std1 = new Student() { FirstName = "Yash 12312313113", LastName = "Malhotra 23123123", Grade = grd1 };

                ////add entitiy to the context
                context.Students.Add(std1);
                context.SaveChanges();

                var stdAddress = new StudentAddress()
                {
                    Address = "SFO - CA - USA",
                    City = "SFO",
                    State = "CA",
                    Country = "USA",
                    Student = std1
                };
                context.StudentAddresses.Add(stdAddress);
                context.SaveChanges();

                //// Demo về DeleteBehavior.Cascade
                //var grade = context.Grades.Find(7);
                //context.Grades.Remove(grade);
                //context.SaveChanges();

                foreach (var s in context.Students)
                {
                    var createdDate = context.Entry(s).Property("CreatedDate").CurrentValue;
                    Console.WriteLine($"First Name: {s.FirstName}, Last Name: {s.LastName}, Created date: {createdDate}");
                }

                //var student = context.Students.FirstOrDefault();
                //DisplayStates(context.ChangeTracker.Entries());

                //context.Students.Add(new Student() { FirstName = "Bill", LastName = "Gates" });
                //DisplayStates(context.ChangeTracker.Entries());

                //// Update
                //var std = context.Students.First<Student>();
                //std.FirstName = "Steve";
                //context.SaveChanges();
                //DisplayStates(context.ChangeTracker.Entries());

                //foreach (var s in context.Students)
                //{
                //    Console.WriteLine($"First Name: {s.FirstName}, Last Name: {s.LastName}");
                //}

                //// Delete
                //var std1 = context.Students.First<Student>();
                //context.Students.Remove(std);
                //context.SaveChanges();

                //var std = new Student() { FirstName = "Bill", LastName = "Gate", Grade = grd1, Address = stdAddress };
                //context.Add<Student>(std);
                //context.SaveChanges();


                // L2E
                var studentsWithSameName = context.Students
                                      .Where(s => s.FirstName == "Steve")
                                      .ToList();

                var studentWithGrade = context.Students
                                           .Where(s => s.FirstName == "Steve")
                                           .Include(s => s.Grade)
                                           .FirstOrDefault();

                var studentWithGrade1 = context.Students
                        .FromSqlRaw("Select * from Students where FirstName ='Steve'")
                        .Include(s => s.Grade)
                        .FirstOrDefault();
            };


        }

        static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var item in entries)
            {
                Console.WriteLine($"Entity: {item.Entity.GetType().Name}, State: {item.State.ToString()}");
            }
        }
    }
}
