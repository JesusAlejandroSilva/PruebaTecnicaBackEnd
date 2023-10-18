using BusinessLayer.Interfaces;
using BusinessLayer.Services.Implements;
using DataLayer.Interfaces;
using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class DeportistasService : GenericService<Deportistas>, IDeportistaService
    {
        public DeportistasService(IDeportistasRepository deportistasRepository) : base(deportistasRepository)
        {
                
        }
    }
}
