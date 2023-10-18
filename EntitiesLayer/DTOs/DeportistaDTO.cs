using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs
{
    public class DeportistaDTO
    {
        public int ID { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public int Id_Pais { get; set; }


    }
}
