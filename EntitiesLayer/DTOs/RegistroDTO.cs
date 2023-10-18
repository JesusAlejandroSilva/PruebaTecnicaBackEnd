using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs
{
    public class RegistroDTO
    {
        public int ID { get; set; }
        public int Id_Deportista { get; set; }
        public string Modalidad { get; set; }
        public int Peso { get; set; }
    }
}
