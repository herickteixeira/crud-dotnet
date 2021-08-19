using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe corretamente o nome")]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
