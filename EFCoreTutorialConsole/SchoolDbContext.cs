using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTutorialConsole
{
    internal class SchoolDbContext : DbContext
    {
        IConfiguration appConfig;

        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public SchoolDbContext()
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(appConfig.GetConnectionString("SchoolDBLocalConnection"));
        }
    }
}
