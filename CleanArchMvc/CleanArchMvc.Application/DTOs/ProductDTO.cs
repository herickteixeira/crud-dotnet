using CleanArchMvc.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe corretamente o nome")]
        [MinLength(3)]
        [MaxLength(40)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe corretamente a descrição")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Informe corretamente o preço")]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Informe corretamente o stock")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Image")]
        public string Image { get; set; }

        [DisplayName("Categories")]
        public Category Category { get; set; }        
        public int CategoryId { get; set; }
    }
}
