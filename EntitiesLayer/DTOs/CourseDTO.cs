using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer.DTOs
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "The field CourseId is Required ")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "The field Title Is Required")]
        [StringLength(50)]
        public string Title { get; set; }

        public int Credits { get; set; }

    }
}
