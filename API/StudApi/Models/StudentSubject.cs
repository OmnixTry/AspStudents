using System.ComponentModel.DataAnnotations;

namespace StudApi.Models
{
    public class StudentSubject
    {
        [Required]
        public int StudentId { get; set; } 

        [Required]
        public int SubjectId { get; set; }

    }
}
