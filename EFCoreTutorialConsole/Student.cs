using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTutorialConsole
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[]? Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public int GradeId { get; set; }
        public Grade? Grade { get; set; }

        public StudentAddress? Address { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
