using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLayer.Models
{
    [Table("Registros", Schema = "dbo")]
    public class Registros
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Deportistas")]
        public int Id_Deportista { get; set; }
        public string Modalidad { get; set; }
        public int Peso { get; set; }


        public Deportistas Deportistas { get; set; }
    }
}
