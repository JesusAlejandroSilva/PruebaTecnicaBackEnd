using BusinessLayer.Interfaces;
using BusinessLayer.Services.Implements;
using DataLayer.Interfaces;
using EntitiesLayer.Models;

namespace BusinessLayer.Services
{
    public class CourseService: GenericService<Course>, ICourseService
    {
        public CourseService(ICourseRepository courseRepository): base(courseRepository)
        {
                
        }
    }
}
