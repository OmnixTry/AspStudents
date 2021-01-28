using System.ComponentModel.DataAnnotations;

namespace StudApi.Models
{
    public class Student : Interfaces.ICopyable<Student>
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronimic { get; set; }

        public void CopyProperties(Student data)
        {
            Name = data.Name;
            Surname = data.Surname;
            Patronimic = data.Patronimic;
        }
    }
}
