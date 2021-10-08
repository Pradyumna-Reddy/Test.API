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
    public class GradesController : ControllerBase
    {
        public ApplicationDbContext DbContext { get; }

        public GradesController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // GET: api/<GradesController>
        [HttpGet]
        public ActionResult<IEnumerable<Grade>> Get()
        {
            return Ok(DbContext.Grades.ToList());
        }

        // GET api/<GradesController>/5
        [HttpGet("{id}")]
        public ActionResult<Grade> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var grade = DbContext.Grades.Where(a => a.Id == id).SingleOrDefault();
            if (grade == null)
            {
                return NotFound();
            }
            return Ok(grade);
        }

        // POST api/<GradesController>
        [HttpPost]
        public ActionResult<Grade> Post([FromBody] Grade grade)
        {
            DbContext.Grades.Add(grade);
            DbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = grade.Id }, grade);
        }

        // PUT api/<GradesController>/5
        [HttpPut("{id}")]
        public ActionResult<Grade> Put(int id, [FromBody] Grade grade)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var gradeInDb = DbContext.Grades.Find(id);
            if (gradeInDb == null)
            {
                return NotFound();
            }
            gradeInDb.GradeName = grade.GradeName;
            DbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = grade.Id }, grade);
        }

        // DELETE api/<GradesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var gradeInDb = DbContext.Grades.Find(id);
            if (gradeInDb == null)
            {
                return NotFound();
            }
            DbContext.Grades.Remove(gradeInDb);
            DbContext.SaveChanges();
            return NoContent();
        }

    }
}

