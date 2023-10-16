using AutoMapper;
using BusinessLayer.Services;
using DataLayer.DBContext;
using DataLayer.Repositories;
using EntitiesLayer.DTOs;
using EntitiesLayer.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Test.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(TestContext.Create()));

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet] 
        public async Task<IHttpActionResult> GetAllCourse()
        {
            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));

            return Ok(coursesDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByIdCourse(int id) 
        {
            var course = await courseService.GetById(id);

            if (course == null)
                return NotFound();
            
            var courseDTO = mapper.Map<CourseDTO>(course);

            return Ok(courseDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertCourse(CourseDTO coursesDTO) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var course = mapper.Map<Course>(coursesDTO);
                course = await courseService.Insert(course);
                return Ok(course);

            } 
            catch (System.Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateCourse(CourseDTO courseDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (courseDTO.CourseID != id)
                return BadRequest();

            var courseid = await courseService.GetById(id);

            if (courseid == null)
                return NotFound();
            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);

                return Ok(course);

            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCourse(int id)
        {
            var courseid = await courseService.GetById(id);

            if (courseid == null)
                return NotFound();
            try
            {
                await courseService.Delete(id);
                return Ok();

            }
            catch (System.Exception ex)
            {


                return InternalServerError(ex);
            }


        }


    }
}
