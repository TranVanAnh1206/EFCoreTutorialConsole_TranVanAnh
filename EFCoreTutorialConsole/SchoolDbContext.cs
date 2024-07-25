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
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SchoolDb;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(appConfig.GetConnectionString("SchoolDBLocalConnection"));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(x => x.StudentId)
                .IsRequired();

            // O2M
            modelBuilder.Entity<Student>()
                .HasOne<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId)
                .OnDelete(DeleteBehavior.Cascade);

            // O2O
            modelBuilder.Entity<Student>()
                .HasOne<StudentAddress>(s => s.Address)
                .WithOne(x => x.Student)
                .HasForeignKey<StudentAddress>(x => x.AddressOfStudentId);

            // M2M
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            // Shadow property
            modelBuilder.Entity<Student>().Property<DateTime>("CreatedDate").HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<Student>().Property<DateTime>("UpdatedDate").HasDefaultValueSql("GETUTCDATE()");

            // Config shadow property trên tất cả các entity
            //var allEntities = modelBuilder.Model.GetEntityTypes();
            //foreach (var entity in allEntities)
            //{
            //    entity.AddProperty("CreatedDate", typeof(DateTime));
            //    entity.AddProperty("UpdatedDate", typeof(DateTime));
            //}

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //var entries =  ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            //foreach (var entityEntry in entries)
            //{
            //    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

            //    if (entityEntry.State == EntityState.Added)
            //    {
            //        entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
            //    }
            //}

            return base.SaveChanges();
        }
    }
}
