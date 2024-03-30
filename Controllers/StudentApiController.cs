using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeAPIStudent.Models;
using PracticeAPIStudent.Data;

namespace PracticeAPIStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly ApiContext _context;

        public StudentApiController(ApiContext context) 
        {
            _context = context;
        }
        //Create//Edit

        [HttpPost]
        
        public JsonResult CreateEdit(StudentInfo student)
        {
            if (student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                var existingStudent = _context.Students.Find(student.Id);

                if (existingStudent == null)
                {
                    return new JsonResult(NotFound());
                }

                existingStudent = student;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(student));
        }
        [HttpGet]
        public JsonResult Get(int Id)
        {
            var result = _context.Students.Find(Id);

            if(result == null){
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok());
        }

        [HttpDelete]

        public JsonResult Delete(int Id)
        {
            var result = (_context.Students.Find(Id));

            if(result == null)
            {
                return new JsonResult(NotFound());

            }
            _context.Students.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
