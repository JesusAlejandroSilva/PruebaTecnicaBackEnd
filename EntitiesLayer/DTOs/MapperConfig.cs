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
                cfg.CreateMap<Paises, PaisesDTO>(); // GET
                cfg.CreateMap<PaisesDTO, Paises>(); // POST - PUT

                cfg.CreateMap<Deportistas, DeportistaDTO>();
                cfg.CreateMap<DeportistaDTO, Deportistas>();

                cfg.CreateMap<Registros, RegistroDTO>();
                cfg.CreateMap<RegistroDTO, Registros>();
            });
        
        }
    }
}
