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
    }
}
