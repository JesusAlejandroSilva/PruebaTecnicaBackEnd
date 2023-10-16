using AutoMapper;
using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration() {

            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>(); // GET
                cfg.CreateMap<CourseDTO, Course>(); // POST - PUT

                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();
            });
        
        }
    }
}
