using DataLayer.DBContext;
using DataLayer.Interfaces;
using DataLayer.Repositories.Implements;
using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(TestContext testContext) : base(testContext)
        {
                
        }
    }
}
