using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw10.Dtos;
using cw10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var db = new s17179Context();

            return Ok(db.Student.ToList());
        }

        [HttpPut("{indexNumber}")]
        public IActionResult UpdateStudent(string indexNumber, StudentDto studentDto)
        {
            var db = new s17179Context();

            var student = db.Student
                .Where(s => s.IndexNumber == indexNumber)
                .Single();

            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            db.SaveChanges();

            return Ok(student);
        }

        [HttpDelete("{indexNumber}")]
        public IActionResult RemoveStudent(string indexNumber)
        {
            var db = new s17179Context();

            var student = db.Student
                .Where(s => s.IndexNumber == indexNumber)
                .Single();

            db.Remove(student);
            db.SaveChanges();

            return Ok();
        }
    }
}
