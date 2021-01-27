using System.ComponentModel.DataAnnotations;

namespace StudApi.Models
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Room { get; set; }
    }
}
