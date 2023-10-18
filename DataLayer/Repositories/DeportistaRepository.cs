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
    public class DeportistaRepository: GenericRepository<Deportistas>, IDeportistasRepository
    {
        public DeportistaRepository(TestContext testContext) : base(testContext)
        {
                
        }
    }
}
