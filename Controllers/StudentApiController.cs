﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeAPIStudent.Models;
using PracticeAPIStudent.Data;

namespace PracticeAPIStudent.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly ApiContext _context;

        public StudentApiController(ApiContext context)
        {
            _context = context;
        }
        //GET: api/students
        [HttpGet("get/{Id}")]
        public IActionResult Get(int Id)
        {
            var result = _context.Students.Find(Id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }

        // GET: api/students/all
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var result = _context.Students.ToList();

            return new JsonResult(Ok(result));
        }
        // POST: api/students
        [HttpPost]
        public IActionResult Create(StudentInfo student)
        { 
            _context.Students.Add(student);
            _context.SaveChanges();

            return new JsonResult(Ok(student));
        }

        //POST : api/students/update

        [HttpPut]

        public IActionResult Update(StudentInfo student)
        {
            var existingStudent = _context.Students.Find(student.Id);

            if (existingStudent == null)
            {
                return new JsonResult(NotFound());
            }
            //update existing student data

            existingStudent.Name = student.Name;
            existingStudent.Roll = student.Roll;    

            _context.SaveChanges();

            return new JsonResult(Ok(existingStudent));


        }
        
        //DELETE: api/students/{id}
        [HttpDelete("delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            var result = _context.Students.Find(Id);

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
