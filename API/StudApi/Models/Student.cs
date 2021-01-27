using System.ComponentModel.DataAnnotations;

namespace StudApi.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronimic { get; set; }
    }
}
