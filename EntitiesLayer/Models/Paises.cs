using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLayer.Models
{
    [Table("Paises", Schema = "dbo")]
    public class Paises
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Iniciales { get; set; }

        public virtual ICollection<Deportistas> Deports { get; set; }
    }
}
