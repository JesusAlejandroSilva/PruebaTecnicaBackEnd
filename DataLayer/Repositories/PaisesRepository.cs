using DataLayer.DBContext;
using DataLayer.Interfaces;
using DataLayer.Repositories.Implements;
using EntitiesLayer.Models;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class PaisesRepository: GenericRepository<Paises>, IPaisesRepository
    {
        public PaisesRepository(TestContext testContext) : base(testContext)
        {

        }
    }
}
