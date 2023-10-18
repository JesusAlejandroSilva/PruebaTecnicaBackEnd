using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLayer.Models
{
    [Table("Deportistas", Schema = "dbo")]
    public class Deportistas
    {
        [Key]
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [ForeignKey("Paises")]
        public int Id_Pais { get; set; }



        public Paises Paises { get; set; }

        public virtual ICollection<Registros> Registros { get; set; }

    }
}
