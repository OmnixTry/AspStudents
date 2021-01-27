using System.Collections.Generic;

namespace StudApi.Models.DummyData
{
    /// <summary>
    /// Didn't make it static to practice DI
    /// </summary>
    public class DataSource : IDummyData
    {
        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }

        public List<StudentSubject> StudentSubjects { get; set; }

        public DataSource()
        {
            Subjects = new List<Subject>()
            { new Subject() { Id = 1, Room = 101, Title = "Math"},
              new Subject() { Id = 2, Room = 202, Title = "Programming"},
              new Subject() { Id = 3, Room = 303, Title = "Networks"},
              new Subject() { Id = 4, Room = 303, Title = "DataBases"}
            };

            Students = new List<Student>()
            {
                new Student() {Id = 1, Name="Bob", Surname="Cool", Patronimic="Good"},
                new Student() {Id = 2, Name="Garry", Surname="Nice", Patronimic="Bobenko"},
                new Student() {Id = 3, Name="Mario", Surname="Mario", Patronimic="Bro"},
                new Student() {Id = 4, Name="Luigi", Surname="Mario", Patronimic="Bro"}
            };

            StudentSubjects = new List<StudentSubject>()
            {
                new StudentSubject() { StudentId = 1, SubjectId = 1},
                new StudentSubject() { StudentId = 1, SubjectId = 2},
                new StudentSubject() { StudentId = 2, SubjectId = 1},
                new StudentSubject() { StudentId = 2, SubjectId = 2},
                new StudentSubject() { StudentId = 2, SubjectId = 3},
                new StudentSubject() { StudentId = 3, SubjectId = 2},
                new StudentSubject() { StudentId = 3, SubjectId = 3},
                new StudentSubject() { StudentId = 3, SubjectId = 4},
                new StudentSubject() { StudentId = 4, SubjectId = 1},
                new StudentSubject() { StudentId = 4, SubjectId = 2},
                new StudentSubject() { StudentId = 4, SubjectId = 3},
                new StudentSubject() { StudentId = 4, SubjectId = 4}
            };
        }
    }
}
