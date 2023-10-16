using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataLayer.DBContext;
using DataLayer.Repositories;
using EntitiesLayer.DTOs;
using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Test.API.Controllers
{
   // [Authorize]
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {
        private IMapper mapper;
        private readonly StudentService studentService = new StudentService(new StudentRepository(TestContext.Create()));

        public StudentsController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
                
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllStudent()
        {
            var students = await studentService.GetAll();
            var studentDTO = students.Select(x => mapper.Map<StudentDTO>(x));

            return Ok(studentDTO);
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetByIdStudent(int id)
        {
            var students = await studentService.GetById(id);

            if (students == null)
                return NotFound();

            var studentsDTO = mapper.Map<StudentDTO>(students);

            return Ok(studentsDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertStundent(StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var student = mapper.Map<Student>(studentDTO);
                student = await studentService.Insert(student);
                return Ok(student);

            }
            catch (System.Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateStudent(StudentDTO studentDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (studentDTO.ID != id)
                return BadRequest();

            var studentid = await studentService.GetById(id);

            if (studentid == null)
                return NotFound();
            try
            {
               var student = mapper.Map<Student>(studentDTO);
               student = await studentService.Update(student);

                return Ok(student);

            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            var courseid = await studentService.GetById(id);

            if (courseid == null)
                return NotFound();
            try
            {
                await studentService.Delete(id);
                return Ok();

            }
            catch (System.Exception ex)
            {


                return InternalServerError(ex);
            }


        }

    }
}
