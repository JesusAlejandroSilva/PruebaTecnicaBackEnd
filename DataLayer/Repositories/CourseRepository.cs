using DataLayer.DBContext;
using DataLayer.Interfaces;
using DataLayer.Repositories.Implements;
using EntitiesLayer.Models;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CourseRepository: GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(TestContext testContext) : base(testContext)
        {

        }
    }
}
