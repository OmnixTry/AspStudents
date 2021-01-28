using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudApi.Models.DummyData
{
    public interface IDummyData
    {
        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }

        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
