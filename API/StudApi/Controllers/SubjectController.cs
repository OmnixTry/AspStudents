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
    public class SubjectController : ControllerBase
    {
        private readonly IDummyData _data;
        public SubjectController(IDummyData data)
        {
            _data = data;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public List<Subject> Get()
        {
            //return new string[] { "value1", "value2" };
            return _data.Subjects;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Subject subject = _data.Subjects.Find(s => s.Id == id);
            if (subject == null)
                return BadRequest();
            else
                return new JsonResult(subject);
        }

        // POST api/<StudentController>
        [HttpPost]
        public int Post([FromBody] Subject value)
        {
            // replace given id with the necessary one
            int maxId = _data.Subjects.Select(s => s.Id).Max();
            value.Id = ++maxId;

            // add to list and return id of the new object
            _data.Subjects.Add(value);
            return maxId;
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Subject value)
        {
            if (!_data.Subjects.Exists(s => s.Id == id))
                return BadRequest();
            _data.Subjects.Find(s => s.Id == id).CopyProperties(value);
            return Ok();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _data.Subjects.RemoveAll(s => s.Id == id);
        }

        
    }
}
