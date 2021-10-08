using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public ApplicationDbContext DbContext { get; }

        public StudentsController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return Ok(DbContext.Students.ToList());
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var student = DbContext.Students.Where(a => a.Id == id).SingleOrDefault();
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            DbContext.Students.Add(student);
            DbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Student> Put(int id, [FromBody] Student student)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var studentInDb = DbContext.Students.Find(id);
            if (studentInDb == null)
            {
                return NotFound();
            }
            studentInDb.Name = student.Name;
            studentInDb.GradeId = student.GradeId;
            DbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var studentInDb = DbContext.Students.Find(id);
            if (studentInDb == null)
            {
                return NotFound();
            }
            DbContext.Students.Remove(studentInDb);
            DbContext.SaveChanges();
            return NoContent();
        }
    }
}
