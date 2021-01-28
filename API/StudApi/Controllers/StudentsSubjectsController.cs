using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudApi.Models;
using StudApi.Models.DummyData;

namespace StudApi.Controllers
{
    public class StudentsSubjectsController : Controller
    {
        private readonly IDummyData _data;
        public StudentsSubjectsController(IDummyData data)
        {
            _data = data;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SubjectViewModel> models = new List<SubjectViewModel>();
            foreach (var subject in _data.Subjects)
            {
                var students = _data.StudentSubjects.Where(ss => ss.SubjectId == subject.Id).Select(ss => ss.StudentId);
                SubjectViewModel model = new SubjectViewModel()
                {
                    Id = subject.Id,
                    Room = subject.Room,
                    Title = subject.Title,
                    Students = _data.Students.Where(s => students.Contains(s.Id)).ToList()
                };
                models.Add(model);
            }
            return View(models);
        }
    }
}
