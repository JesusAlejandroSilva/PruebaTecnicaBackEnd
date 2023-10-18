using BusinessLayer.Interfaces;
using BusinessLayer.Services.Implements;
using DataLayer.Interfaces;
using EntitiesLayer.Models;

namespace BusinessLayer.Services
{
    public class PaisesService: GenericService<Paises>, IPaisesService
    {
        public PaisesService(IPaisesRepository paisesRepository): base(paisesRepository)
        {
                
        }
    }
}
