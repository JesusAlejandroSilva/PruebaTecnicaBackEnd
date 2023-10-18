using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer.DTOs
{
    public class PaisesDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The field CourseId is Required ")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "The field Title Is Required")]
        [StringLength(50)]
        public string Iniciales { get; set; }

    }
}
