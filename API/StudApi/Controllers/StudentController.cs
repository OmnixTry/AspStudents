using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudApi.Models;
using StudApi.Models.DummyData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDummyData _data;
        public StudentsController(IDummyData data)
        {
            _data = data;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> Get()
        {
            //return new string[] { "value1", "value2" };
            return _data.Students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student student = _data.Students.Find(s => s.Id == id);
            if (student == null)
                return BadRequest();
            else
                return new JsonResult(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public int Post([FromBody] Student value)
        {
            // replace given id with the necessary one
            int maxId = _data.Students.Select(s => s.Id).Max();
            value.Id = ++maxId;
            
            // add to list and return id of the new object
            _data.Students.Add(value);
            return maxId;
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student value)
        {
            if (!_data.Students.Exists(s => s.Id == id))
                return BadRequest();
            _data.Students.Find(s => s.Id == id).CopyProperties(value);
            return Ok();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _data.Students.RemoveAll(s => s.Id == id);
        }

        [HttpGet("{id}/subjects")]
        public List<Subject> GetSubjects(int id)
        {
            return (from subject in _data.Subjects
                   where (from ssid in _data.StudentSubjects
                          where ssid.StudentId == id
                          select ssid.SubjectId).Contains(subject.Id)
                   select subject).ToList();
        }

        [HttpPost("{id}/subjects")]
        public IActionResult PostSubj (int id, [FromQuery] int subjectId)
        {
            if (ValidateSubject(id, subjectId)
                && !ExistSubStud(id, subjectId))
            {
                _data.StudentSubjects.Add(new StudentSubject() { StudentId = id, SubjectId = subjectId });
                return Ok();
            }
            else return BadRequest();
        }

        [HttpDelete("{id}/subjects")]
        public IActionResult DeleteSubj(int id, [FromQuery] int subjectId)
        {
            if (ValidateSubject(id, subjectId)
                && ExistSubStud(id, subjectId))
            {
                _data.StudentSubjects.RemoveAll(ss => ss.StudentId == id && ss.SubjectId == subjectId);
                return Ok();
            }
            else return BadRequest();
        }

        private bool ExistSubStud(int id, int subjectId)
        {
            return _data.StudentSubjects.Exists(ss => ss.SubjectId == subjectId && ss.StudentId == id);
        }

        private bool ValidateSubject(int id, int subjectId)
        {
            return _data.Students.Exists(s => s.Id == id) &&
                _data.Subjects.Exists(s => s.Id == subjectId);
        }
    }
}
